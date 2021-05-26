import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {
  NbAuthComponent,
  NbLoginComponent,
  NbLogoutComponent,
  NbRegisterComponent,
  NbRequestPasswordComponent,
  NbResetPasswordComponent
} from '@nebular/auth';

export const routes: Routes = [
  {path: 'auth', component: NbAuthComponent, children: [
      {path: 'login', component: NbLoginComponent},
      {path: 'register', component: NbRegisterComponent},
      {path: 'logout', component: NbLogoutComponent},
      {path: 'request-password', component: NbRequestPasswordComponent},
      {path: 'reset-password', component: NbResetPasswordComponent}
    ]}
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
