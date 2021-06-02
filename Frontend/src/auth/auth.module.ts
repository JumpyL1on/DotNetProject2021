import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {NbAlertModule, NbButtonModule, NbCheckboxModule, NbInputModule} from '@nebular/theme';
import {NB_AUTH_TOKEN_INTERCEPTOR_FILTER, NbAuthJWTInterceptor, NbAuthJWTToken, NbAuthModule, NbPasswordAuthStrategy} from '@nebular/auth';
import {environment} from '../environments/environment';
import {HTTP_INTERCEPTORS, HttpRequest} from '@angular/common/http';
import {AuthRoutingModule} from './auth-routing.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AuthRoutingModule,
    NbAlertModule,
    NbInputModule,
    NbButtonModule,
    NbCheckboxModule,
    NbAuthModule.forRoot({
      strategies: [
        NbPasswordAuthStrategy.setup({
          name: 'email',
          token: {
            class: NbAuthJWTToken,
            key: 'token'
          },
          baseEndpoint: environment.webAPI,
          login: {
            endpoint: 'auth/sign-in',
            method: 'post',
            redirect: {
              success: 'sidebar',
              failure: null
            }
          },
          register: {
            endpoint: 'auth/sign-up',
            method: 'post',
            redirect: {
              success: 'auth/login',
              failure: null
            }
          },
          logout: {
            endpoint: 'auth/sign-out',
            method: 'post'
          },
          requestPass: {
            endpoint: 'auth/request-pass',
            method: 'post'
          },
          resetPass: {
            endpoint: 'auth/reset-pass',
            method: 'post'
          }
        })
      ],
      forms: {}
    })
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: NbAuthJWTInterceptor, multi: true},
    {provide: NB_AUTH_TOKEN_INTERCEPTOR_FILTER, useValue: () => false}
  ],
})
export class AuthModule { }
