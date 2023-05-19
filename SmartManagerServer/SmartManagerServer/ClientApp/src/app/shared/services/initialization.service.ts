import { HttpClient } from '@angular/common/http';
import { Injectable, OnDestroy } from '@angular/core';
import { OktaAuthService } from '@okta/okta-angular';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { User } from 'src/app/core/models/common/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InitializationService implements OnDestroy {

  private baseUrl = `${environment.apiRootUrl}`;
  private user: User | null = null;
  public $userChanged = new BehaviorSubject<User | null>(null);
  //public $user = new BehaviorSubject<User | null>(null);

  isAuthenticated: boolean = false;
  firstInit: boolean = true;

  constructor(private http: HttpClient, public oktaAuth: OktaAuthService) { }

  ngOnDestroy(): void {
    this.$userChanged.unsubscribe();
  }

  private fetchUser(): Observable<User> {
    return this.http.get<User>(`${this.baseUrl}initialization`).pipe(
      tap(user => {
        this.user = user;
        this.$userChanged.next(user);
      })
    );
  }

  private getUser(isAuthenticated: boolean) {
    console.log(`GET USER`);
    if (isAuthenticated == true) {
      this.fetchUser().subscribe(user => {
        this.user = user;        
      });
    }
    else {
      this.clearUser();
    }
  }

get user$(): Observable<User | null>{
  if(this.user == null) return this.fetchUser();
  else return this.$userChanged.asObservable();
}

  private clearUser() {
    this.user = null;
    this.$userChanged.next(null);
  }

}
