import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompaniesListComponent } from './components/companies/companies-list/companies-list.component';

const routes: Routes = [
  {
    path:'',
    component: CompaniesListComponent
  },
  {
    path:'companies',
    component: CompaniesListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
