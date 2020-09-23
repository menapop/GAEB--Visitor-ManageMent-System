import { SecuriedPagesGuard } from './shared/Security/securied-pages.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'search',
    loadChildren: () => import('./Components/search/search.module').then(m => m.SearchModule),
  },
  
  {
    path: 'register',
    loadChildren: () => import('./Components/registeration/registeration.module').then(m => m.RegisterationModule),
  },
  {
    path: 'request',
    loadChildren: () => import('./Components/request/request.module').then(m => m.RequestModule),
    canActivate: [SecuriedPagesGuard]
  },
  {
    path: '**',
    loadChildren: () => import('./Components/search/search.module').then(m => m.SearchModule),
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
