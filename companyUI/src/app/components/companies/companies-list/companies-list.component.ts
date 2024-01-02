import { Component, OnInit, importProvidersFrom } from '@angular/core';
import { Company } from 'src/app/models/company-model';
import { CompaniesService } from 'src/app/services/companies.service';
@Component({
  selector: 'app-companies-list',
  templateUrl: './companies-list.component.html',
  styleUrls: ['./companies-list.component.css']
})
export class CompaniesListComponent implements OnInit {
 
 companies : Company[] = [];
  constructor(private companiesservices: CompaniesService){

 }

 ngOnInit(): void {
  this.companiesservices.getAllCompanies()
  .subscribe({
    next: (companies) =>{
      this.companies = companies;
    },
    error: (response) => {
      console.log(response)
    }
  });
 }
}
