import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { EmployeeModel } from './models/employee-model';
import { DepartmentEarningModel } from '../dashboard/models/department-earning-model';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, RouterLink } from '@angular/router';

@Component({
  selector: 'app-employees',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.css'
})
export class EmployeesComponent implements OnInit {
  ngOnInit(): void {
    this.getEmployees();
    this.getDepartments();
  }

  activedRoute = inject(ActivatedRoute);


  http = inject(HttpClient)

  employees: EmployeeModel[] = [];
  departments: string[] = [];
  selectDepartmentOption = "";

  changeSelectDeparatment(){
    this.getEmployees();
  }

  getEmployees() {
    this.http.get<EmployeeModel[]>(`http://localhost:5003/api/stake-holder-employees/employees?filter=${this.selectDepartmentOption}`)
      .subscribe({
        next: (res: EmployeeModel[]) => {
          this.employees = res;
        },
        error: (err) => {
          console.log(err);
        }
      })
  }

  getDepartments() {
    this.http.get<DepartmentEarningModel[]>("http://localhost:5003/api/dashboard/get-department-earning")
      .subscribe({
        next: (res) => {
          this.departments = [];
          res.forEach(d => {
            this.departments.push(d.departmentName);
          });
        },
        error: (error) => {
          console.log(error);
        }
      })
  }
}

