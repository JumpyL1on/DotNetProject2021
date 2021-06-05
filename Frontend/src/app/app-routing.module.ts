import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {UnassignedCasesComponent} from './cases/unassigned-cases/unassigned-cases.component';
import {ClosedCasesComponent} from './cases/closed-cases/closed-cases.component';
import {EnabledTeamMembersComponent} from './team-members/enabled-team-members/enabled-team-members.component';
import {DeletedTeamMembersComponent} from './team-members/deleted-team-members/deleted-team-members.component';
import {CasesSidebarComponent} from './cases/cases-sidebar/cases-sidebar.component';
import {TeamMembersSidebarComponent} from './team-members/team-members-sidebar/team-members-sidebar.component';
import {AuthGuard} from '../auth/auth.guard';
import {SidebarComponent} from './sidebar/sidebar.component';
import {AssignedToMeCasesComponent} from './cases/assigned-to-me-cases/assigned-to-me-cases.component';
import {CaseDetailsComponent} from './cases/case-details/case-details.component';
import {
  NbAuthComponent,
  NbLoginComponent,
  NbLogoutComponent,
  NbRegisterComponent,
  NbRequestPasswordComponent,
  NbResetPasswordComponent
} from '@nebular/auth';
import {OpenCasesComponent} from './cases/open-cases/open-cases.component';

const routes: Routes = [
  {path: '', redirectTo: 'sidebar', pathMatch: 'full'},
  {path: 'auth', component: NbAuthComponent, children: [
      {path: 'login', component: NbLoginComponent},
      {path: 'register', component: NbRegisterComponent},
      {path: 'logout', component: NbLogoutComponent},
      {path: 'request-password', component: NbRequestPasswordComponent},
      {path: 'reset-password', component: NbResetPasswordComponent}
    ]},
  {path: 'sidebar', component: SidebarComponent, canActivate: [AuthGuard], children: [
      {path: 'cases', component: CasesSidebarComponent, children: [
          {path: 'unassigned', component: UnassignedCasesComponent},
          {path: 'assigned-to-me', component: AssignedToMeCasesComponent, children: [
              {path: ':id', component: CaseDetailsComponent}
            ]},
          {path: 'open', component: OpenCasesComponent, children: [
              {path: ':id', component: CaseDetailsComponent}
            ]},
          {path: 'closed', component: ClosedCasesComponent}
        ]},
      {path: 'team-members', component: TeamMembersSidebarComponent, children: [
          {path: 'enabled', component: EnabledTeamMembersComponent},
          {path: 'deleted', component: DeletedTeamMembersComponent}
        ]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
