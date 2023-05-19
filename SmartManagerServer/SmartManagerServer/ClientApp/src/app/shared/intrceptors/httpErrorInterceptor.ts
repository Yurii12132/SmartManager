import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpResponse,
    HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { SnackBarService } from '../services/snack-bar.service';
import { IInteractionDialogOptions } from 'src/app/core/models/interactionDialog/interactionDialogOptions';
import { AttentionTypes } from 'src/app/core/models/interactionDialog/attentionTypes';
import { InteractionDialogService } from '../services/interaction-dialog.service';
import { CommonService } from '../services/common.service';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

    constructor(private interactionDialogService: InteractionDialogService, private commonService: CommonService, 
        private snackBarService: SnackBarService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request)
            .pipe(
                retry(1),
                //catchError((error: HttpErrorResponse) => {
                catchError((error: any) => {

                    if (this.checkPathForSnackBar(error?.error?.Path) == true) {
                        this.snackBarService.openDanger(error.error.Message, '');
                    }
                    else{
                        let options: IInteractionDialogOptions = {
                            title: "ERROR",
                            message: `${error?.error?.Message}`,
                            details: error?.error?.Stack,
                            attentionType: AttentionTypes.danger,
                            okButtonText: 'Ok',
                            noButtonVisible: false
                        };
    
                        this.interactionDialogService.open(options);
                    }

                    return throwError(() => new Error(error.message));
                })
            )
    }

    private checkPathForSnackBar(path: string): boolean {
        // if (path == '/api/events/event-item-registration-form') return true;
        // if (path == '/api/events/accept') return true;
        return false;
    }
}