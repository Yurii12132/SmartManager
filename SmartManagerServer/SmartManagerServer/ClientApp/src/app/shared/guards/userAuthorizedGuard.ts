import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";
import { OktaAuthService } from "@okta/okta-angular";
//import { OktaAuthStateService } from "@okta/okta-angular";
import { from, Observable, of } from "rxjs";
import { first, map, switchMap } from "rxjs/operators";
import { RouteConstants } from "src/app/core/constants/routeConstants";
import { InitializationService } from "../services/initialization.service";

@Injectable({
    providedIn: 'root'
})
export class UserAuthorizedGuard implements CanActivate {

    constructor(private initService: InitializationService, private oktaAuth: OktaAuthService, private router: Router) {

    }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {
        const isAuthenticatedObservable = from(this.oktaAuth.isAuthenticated());

        const getUser = (isAuthenticated: boolean) => {
            if (isAuthenticated == false) return of(false);
            return this.initService.user$.pipe(
                map(user => {
                    if (user == null) {
                        this.router.navigate([`/${RouteConstants.ACCESS_DENIED}`]);
                        return false;
                    }
                    return true;
                })
            );
        }

        return isAuthenticatedObservable.pipe(
            switchMap(isAuthenticated => {
                return getUser(isAuthenticated);
            })
        );
    }
}