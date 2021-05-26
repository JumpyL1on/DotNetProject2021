import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';
import {NbAlertModule, NbButtonModule, NbCheckboxModule, NbInputModule} from '@nebular/theme';
import {NbAuthJWTInterceptor, NbAuthJWTToken, NbAuthModule, NbPasswordAuthStrategy} from '@nebular/auth';
import {AuthRoutingModule} from './auth-routing.module';
import {environment} from '../environments/environment';
import {HTTP_INTERCEPTORS} from '@angular/common/http';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    NbAlertModule,
    NbInputModule,
    NbButtonModule,
    NbCheckboxModule,
    AuthRoutingModule,
    NbAuthModule.forRoot({
      strategies: [
        NbPasswordAuthStrategy.setup({
          name: 'email',
          token: {
            class: NbAuthJWTToken,
            key: 'token'
          },
          baseEndpoint: environment.api,
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
  ]
})
export class AuthModule { }
