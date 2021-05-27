import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {AppComponent} from './app.component';
import {ClosedCasesComponent} from './cases/closed-cases/closed-cases.component';
import {UnassignedCasesComponent} from './cases/unassigned-cases/unassigned-cases.component';
import {EnabledComponent} from './team-members/enabled/enabled.component';
import {PendingComponent} from './team-members/pending/pending.component';
import {DisabledComponent} from './team-members/disabled/disabled.component';
import { CasesSidebarComponent } from './cases/cases-sidebar/cases-sidebar.component';
import { TeamMembersComponent } from './team-members/team-members.component';
import {
  NbThemeModule,
  NbLayoutModule,
  NbSidebarModule,
  NbCardModule,
  NbMenuModule,
  NbChatModule,
  NbListModule,
  NbUserModule,
  NbIconModule,
  NbOptionModule,
  NbTreeGridModule, NbSelectModule, NbDialogModule, NbAlertModule, NbInputModule, NbButtonModule, NbCheckboxModule
} from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { SidebarComponent } from './sidebar/sidebar.component';
import { CaseDetailsComponent } from './cases/case-details/case-details.component';
import { AssignedCasesComponent } from './cases/assigned-cases/assigned-cases.component';
import {NbRoleProvider, NbSecurityModule} from '@nebular/security';
import {RoleProvider} from '../auth/role-provider';
import { DialogConfirmComponent } from './dialog-confirm/dialog-confirm.component';
import {
  NB_AUTH_TOKEN_INTERCEPTOR_FILTER,
  NbAuthJWTInterceptor,
  NbAuthJWTToken,
  NbAuthModule,
  NbPasswordAuthStrategy
} from '@nebular/auth';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {environment} from '../environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    ClosedCasesComponent,
    UnassignedCasesComponent,
    EnabledComponent,
    PendingComponent,
    DisabledComponent,
    CasesSidebarComponent,
    TeamMembersComponent,
    SidebarComponent,
    CaseDetailsComponent,
    AssignedCasesComponent,
    DialogConfirmComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    NbThemeModule.forRoot({name: 'default'}),
    NbLayoutModule,
    NbEvaIconsModule,
    CommonModule,
    FormsModule,
    RouterModule,
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
    }),
    NbSidebarModule.forRoot(),
    NbMenuModule.forRoot(),
    NbCardModule,
    NbChatModule,
    NbListModule,
    NbUserModule,
    NbIconModule,
    NbOptionModule,
    NbTreeGridModule,
    NbSelectModule,
    NbSecurityModule.forRoot({
      accessControl: {
        guest: {},
        manager: {
          view: 'assigned-to-me'
        },
        director: {
          view: ['team-members']
        }
      }
    }),
    NbDialogModule.forRoot()
  ],
  providers: [
    {provide: NbRoleProvider, useClass: RoleProvider},
    {provide: HTTP_INTERCEPTORS, useClass: NbAuthJWTInterceptor, multi: true},
    {provide: NB_AUTH_TOKEN_INTERCEPTOR_FILTER, useValue: (req) => false}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


