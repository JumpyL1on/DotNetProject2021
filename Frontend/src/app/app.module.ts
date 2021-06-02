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
import {CasesSidebarComponent} from './cases/cases-sidebar/cases-sidebar.component';
import {TeamMembersComponent} from './team-members/team-members.component';
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
  NbTreeGridModule,
  NbSelectModule,
  NbDialogModule, NbButtonModule,
} from '@nebular/theme';
import {NbEvaIconsModule} from '@nebular/eva-icons';
import {SidebarComponent} from './sidebar/sidebar.component';
import {CaseDetailsComponent} from './cases/case-details/case-details.component';
import {AssignedToMeCasesComponent} from './cases/assigned-to-me-cases/assigned-to-me-cases.component';
import {NbRoleProvider, NbSecurityModule} from '@nebular/security';
import {RoleProvider} from '../auth/role-provider';
import {DialogConfirmComponent} from './dialog-confirm/dialog-confirm.component';
import {HttpClientModule} from '@angular/common/http';
import {CommonModule} from '@angular/common';
import {AuthModule} from '../auth/auth.module';
import { OpenCasesComponent } from './cases/open-cases/open-cases.component';

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
    AssignedToMeCasesComponent,
    DialogConfirmComponent,
    OpenCasesComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    NbThemeModule.forRoot({name: 'default'}),
    NbLayoutModule,
    NbEvaIconsModule,
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
          view: '*' //['team-members', 'unassigned', 'open', 'closed']
        }
      }
    }),
    NbDialogModule.forRoot(),
    AuthModule,
    NbButtonModule
  ],
  providers: [
    {provide: NbRoleProvider, useClass: RoleProvider}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


