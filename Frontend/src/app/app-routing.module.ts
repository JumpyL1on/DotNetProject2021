import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {UnassignedCasesComponent} from './cases/unassigned-cases/unassigned-cases.component';
import {ClosedCasesComponent} from './cases/closed-cases/closed-cases.component';
import {EnabledComponent} from './team-members/enabled/enabled.component';
import {PendingComponent} from './team-members/pending/pending.component';
import {DisabledComponent} from './team-members/disabled/disabled.component';
import {CasesSidebarComponent} from './cases/cases-sidebar/cases-sidebar.component';
import {TeamMembersComponent} from './team-members/team-members.component';
import {AuthGuard} from '../auth/auth.guard';
import {SidebarComponent} from './sidebar/sidebar.component';
import {AssignedCasesComponent} from './cases/assigned-cases/assigned-cases.component';
import {CaseDetailsComponent} from './cases/case-details/case-details.component';
import {
  NbAuthComponent,
  NbLoginComponent,
  NbLogoutComponent,
  NbRegisterComponent,
  NbRequestPasswordComponent,
  NbResetPasswordComponent
} from '@nebular/auth';

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
          {path: 'assigned', component: AssignedCasesComponent, children: [
              {path: 'details', component: CaseDetailsComponent}
            ]},
          {path: 'closed', component: ClosedCasesComponent}
        ]},
      {path: 'team-members', component: TeamMembersComponent, children: [
          {path: 'enabled', component: EnabledComponent},
          {path: 'pending', component: PendingComponent},
          {path: 'disabled', component: DisabledComponent}
        ]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
