import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {AppComponent} from './app.component';
import {ClosedCasesComponent} from './cases/closed-cases/closed-cases.component';
import {UnassignedCasesComponent} from './cases/unassigned-cases/unassigned-cases.component';
import {EnabledTeamMembersComponent} from './team-members/enabled-team-members/enabled-team-members.component';
import {DeletedTeamMembersComponent} from './team-members/deleted-team-members/deleted-team-members.component';
import {CasesSidebarComponent} from './cases/cases-sidebar/cases-sidebar.component';
import {TeamMembersSidebarComponent} from './team-members/team-members-sidebar/team-members-sidebar.component';
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
  NbDialogModule, NbButtonModule, NbActionsModule, NbTagModule,
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
    EnabledTeamMembersComponent,
    DeletedTeamMembersComponent,
    CasesSidebarComponent,
    TeamMembersSidebarComponent,
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
          send: 'message',
          view: 'assigned-to-me'
        },
        director: {
          view: ['team-members', 'unassigned', 'open', 'closed']
        }
      }
    }),
    NbDialogModule.forRoot(),
    AuthModule,
    NbButtonModule,
    NbActionsModule,
    NbTagModule
  ],
  providers: [
    {provide: NbRoleProvider, useClass: RoleProvider}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


