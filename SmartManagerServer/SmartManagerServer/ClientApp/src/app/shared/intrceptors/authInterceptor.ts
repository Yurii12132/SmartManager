import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders } from '@angular/common/http';
//import { OktaAuthStateService } from '@okta/okta-angular';
import { Observable, from, switchMap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { OktaAuthService } from '@okta/okta-angular';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    
  constructor(private oktaAuth: OktaAuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return this.handleAccess(request, next);
  }

  private handleAccess(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (request.url.startsWith(environment.apiRootUrl)) {
      const accessToken = this.oktaAuth.getAccessToken();
     //console.log(`TOKEN: ${accessToken}`);
      request = request.clone({
        setHeaders: {
          Authorization: 'Bearer ' + accessToken
        }
      });
    }
    return next.handle(request);
  }
}