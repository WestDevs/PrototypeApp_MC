import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { GroupsComponent } from './groups/groups.component';
import { HomeComponent } from './home/home.component';
import { LearnerResourcesComponent } from './learner-resources/learner-resources.component';
import { LoginComponent } from './login/login.component';
import { NavComponent } from './nav/nav.component';
import { ReportsComponent } from './reports/reports.component';
import { UserDetailComponent } from './users/user-detail/user-detail.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  // {path: 'app', component: AppComponent},
  // {path: 'home', component: NavComponent},
  {path: 'users', component: UsersComponent},
  {path: 'users/:id', component: UserDetailComponent},
  {path: 'login', component: LoginComponent},
  {path: 'groups', component: GroupsComponent},
  {path: 'learner-resources', component: LearnerResourcesComponent},
  {path: 'reports', component: ReportsComponent},
  {path: '**', component: HomeComponent, pathMatch: 'full'}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
