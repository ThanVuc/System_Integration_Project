import { Component, ElementRef, inject, numberAttribute, OnInit } from '@angular/core';
import { EmployeeDetailModel } from '../models/employee-detail';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-employee-detail',
  standalone: true,
  imports: [],
  templateUrl: './employee-detail.component.html',
  styleUrl: './employee-detail.component.css'
})
export class EmployeeDetailComponent implements OnInit {
  ngOnInit(): void {
    let now = new Date();
    this.getAllDaysInMonth(now.getFullYear(), now.getMonth()+1);
    this.activatedRoute.paramMap.subscribe((params) => {
      if (params.get('id')){
        this.routeId = Number(params.get('id'));
        this.getEmployeeDetail(this.routeId);

      }
    })
  }
  

  activatedRoute = inject(ActivatedRoute);
  http = inject(HttpClient);
  document = inject(DOCUMENT);

  routeId: number = 0;
  days : (number|null) [][] = [];
  weeksInMonth: number[] = [0,1,2,3,4];
  leaveDay: number[] = [];
  month: string = "";
  employee: EmployeeDetailModel = {
    department: "",
    ethinicity: "",
    fullTime: "",
    gender: "",
    id: 0,
    join: "",
    leaveDay: [],
    mail: "",
    name: "",
    phone: "",
    position: "",
    birth: "",
    address: ""
  }

  
  getAllDaysInMonth(year: number, month: number) {

    const monthNames = [
      'JANUARY', 'FEBRUARY', 'MARCH', 'APRIL', 'MAY', 'JUNE',
      'JULY', 'AUGUST', 'SEPTEMBER', 'OCTOBER', 'NOVEMBER', 'DECEMBER'
    ];
  
    // find the days in month
    const daysInMonth = new Date(year, month, 0).getDate();
    const currentDate = new Date(year, month, 0);

    const month_string = monthNames[currentDate.getMonth()];

    this.month = `${month_string} ${year}`;
  
    for (let i=0; i<= 6; i++){
       this.days.push([]);
    }

    // get all day
    for (let day = 1; day <= daysInMonth; day++) {
      let day_tmp = new Date(year, month - 1, day);
      this.days[day_tmp.getDay()].push(day_tmp.getDate());
    }

    if (this.days[0].length < 5){
      let i = 0;
      while (this.days[i].length < 5){
        this.days[i].unshift(null);
        i++;
      }
    } else {
      let i = 6;
      while (this.days[i].length < 5){
        this.days[i].push(null);
        i--;
      }
    }


  }

  getEmployeeDetail(id: number){
    this.http.get<EmployeeDetailModel>("http://localhost:5003/api/stake-holder-employees/employees/"+id)
    .subscribe({
      next: (res: EmployeeDetailModel) => {
        this.employee = res;

        for(let ld of res.leaveDay){
          this.leaveDay.push((new Date(ld)).getDate());
        }

        this.setDayOff(this.leaveDay);
      }
    });
  }

  setDayOff(leaveDay: number[]){
    let eles: Element[] = [];
    this.document.querySelectorAll(".calendar-item").forEach((item) => {
      item.classList.remove('day-off');
      for (let ld of leaveDay){
        if (Number(item.innerHTML) === ld){
          eles.push(item);
        }
      }
    })
  }

}
