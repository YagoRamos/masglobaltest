import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  public employeeId: string;
  public employees: Employee[];
  public http: HttpClient;
  public baseUrl: string;
  public errors = ''

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.http = _http;
    this.baseUrl = _baseUrl;
  }

  search() {
    this.errors = null;

    if (!this.employeeId) {
      this.employeeId = null;
    }

    this.http.get<Employee[]>(this.baseUrl + 'employee/' + this.employeeId).subscribe(result => {
      this.employees = result;
    }, error => {
        console.error(error);
        this.errors = error.error;
    });
  }
}

interface Employee {
  id: number,
  name: string;
  contractTypeName: string;
  roleId: number;
  roleName: string;
  roleDescription: string;
  annualSalary: string;
}