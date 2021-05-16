import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { LoginPageComponent } from './login-page/login-page.component'
const routes: Routes = [
  { path: 'login', component: LoginPageComponent }
];
export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
