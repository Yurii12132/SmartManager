import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { SharedModule } from './shared/shared.module';
import { PagesModule } from './pages/pages.module';
import { OktaAuthModule, OKTA_CONFIG } from '@okta/okta-angular';
import { environment } from 'src/environments/environment';
import { InitializationService } from './shared/services/initialization.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './shared/intrceptors/authInterceptor';
import { HttpErrorInterceptor } from './shared/intrceptors/httpErrorInterceptor';

const oktaConfig = {
  issuer: environment.issuer,
  redirectUri: environment.redirectUri,
  clientId: environment.clientId,
  //scopes:environment.scopes,
  //pkce: environment.pkce,
  // tokenManager:{
  //   autoRenew: true,
  //   secure: true,
  //   storage: 'localStorage',
  // }
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    SharedModule,
    PagesModule,
    OktaAuthModule
  ],
  providers: [
    InitializationService,
    { provide: OKTA_CONFIG, useValue: oktaConfig },
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
