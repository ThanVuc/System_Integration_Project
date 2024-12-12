import { DOCUMENT } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { AfterViewChecked, AfterViewInit, Component, inject, OnInit } from '@angular/core';
import { TimeUnit, Chart, registerables, scales, ChartConfiguration, DatasetChartOptions, DatasetController, DatasetControllerChartComponent, ChartData, ChartDataset, ChartItem } from 'chart.js';
import { ShareHolder, ShareHolderModel } from './models/share-holder-model';
import { map } from 'rxjs';
import { SyntheticModel } from './models/synthetic-model';
import { DepartmentEarningModel } from './models/department-earning-model';
import { EthnicityEarningModel } from './models/ethnicity-earning-model';
import { GenderEarningModel } from './models/gender-earning-model';
import { WorktimeEarningModel } from './models/worktime-earning-model';
import { ProjectModel } from './models/project-earning-model';
Chart.register(...registerables);

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent implements OnInit {
  document = inject(DOCUMENT);
  http = inject(HttpClient);

  ngOnInit(): void {

    if (this.document.readyState == "complete"){
      this.getSyntheticEarning();
      this.getShareHolder();
      this.getDepartmentEarning();
      this.getEthnicityEarning();
      this.getGenderEarning();
      this.getWorkingTimeEarning();
      this.getProject();
    }

    this.document.addEventListener("DOMContentLoaded", () => {
      this.getShareHolder();
      this.getDepartmentEarning();
      this.getEthnicityEarning();
      this.getGenderEarning();
      this.getWorkingTimeEarning();
      this.getProject();
    });
  }

  showCharts(id: string, option: any){
    this.shareHolderEarningChart = new Chart(id,option);
  }

  total: number = 0;
  shareHolders: ShareHolder[] = [];
  departments: DepartmentEarningModel[] = [];
  syntheticEarningModel: SyntheticModel = {
    benefit: 0,
    totalEarning: 0
  }

  shareHolderEarningChart!: Chart;
  departmentEarningChar!: Chart;
  ethnicityEarningChart!: Chart;
  genderEarningChart!: Chart;
  workingTimeEarningChart!: Chart;
  projectsChart!: Chart

  dataset: any;

  data: ChartData = {
    labels: [],
    datasets: []
  }

  option: ChartConfiguration = {
    type: 'bar',
    data: this.data,
    options: {
      scales: {
        y: {
          beginAtZero: true
        }
      }
    }
  }

  getShareHolder(){
    this.http.get<ShareHolderModel>("http://localhost:5003/api/dashboard/get-shareholder-earning")
    .subscribe({
      next: (res: ShareHolderModel) => {
        this.total = res.total;
        this.shareHolders = res.shareHolder;
        let labels = [];
        let shareHolderEarning = [];
        for (let s of this.shareHolders){
          labels.push(s.name);
          shareHolderEarning.push(s.sharesOwned);
        }

        this.dataset = [{
          label: `ShareHolder Earning (Total: ${this.total})`,
          data: shareHolderEarning,
          backgroundColor: [
            'rgb(35, 241, 241)'
          ],
          borderWidth: 1,
          barPercentage: 0.5
        }];

        this.data = {
          labels: labels,
          datasets: this.dataset
        };

        this.option = {
          type: 'bar',
          data: this.data,
          options: {
            scales: {
              y: {
                beginAtZero: true
              }
            }
          }
        }

        this.showCharts("share-holder-earning",this.option);
      },
      error : (err) => {
        console.error(err);
      }
    });
  }

  getSyntheticEarning(){
    this.http.get<SyntheticModel>("http://localhost:5003/api/dashboard/get-synthetic-earning")
    .subscribe({
      next: (res:SyntheticModel) => {
        this.syntheticEarningModel = res;
      },
      error: (err) => {
        console.error(err);
      }
    })
  }

  getDepartmentEarning(){
    this.http.get<DepartmentEarningModel[]>("http://localhost:5003/api/dashboard/get-department-earning")
    .subscribe({
      next: (res: DepartmentEarningModel[]) => {
        let labels: string[] = [];
        let data: number[] = [];

        res.forEach(d => {
          labels.push(d.departmentName);
          data.push(d.totalEarning);
        });

        this.dataset = [{
          label: `Total Earning of Department`,
          data: data,
          backgroundColor: [
            'rgb(19, 111, 19)'
          ],
          borderWidth: 1,
          barPercentage: 0.5
        }];

        this.data = {
          labels: labels,
          datasets: this.dataset
        }

        this.option = {
          data: this.data,
          type: 'bar',
          options: {

          }
        }

        this.departmentEarningChar = new Chart("department-earning",this.option);
      },
      error: (error) => {
        console.error(error);
      }
    })
  }

  getEthnicityEarning(){
    this.http.get<EthnicityEarningModel[]>("http://localhost:5003/api/dashboard/get-ethnicity-earning")
    .subscribe({
      next: (res: EthnicityEarningModel[]) => {
        let labels: string[] = [];
        let data: number[] = [];

        res.forEach(d => {
          labels.push(d.ethnicity);
          data.push(d.totalEarning);
        });

        this.dataset = [{
          label: `Total Earning of Ethinicity`,
          data: data,
          backgroundColor: [
            'rgb(19, 111, 19)'
          ],
          borderWidth: 1,
          barPercentage: 0.5
        }];

        this.data = {
          labels: labels,
          datasets: this.dataset
        }

        this.option = {
          data: this.data,
          type: 'bar',
          options: {

          }
        }

        this.ethnicityEarningChart = new Chart("ethnicity-earning",this.option);
      },
      error: (error) => {
        console.error(error);
      }
    })
  }

  getGenderEarning(){
    this.http.get<GenderEarningModel[]>("http://localhost:5003/api/dashboard/get-gender-earning")
    .subscribe({
      next: (res: GenderEarningModel[]) => {
        let labels: string[] = [];
        let data: number[] = [];

        res.forEach(d => {
          labels.push(d.gender);
          data.push(d.totalEarning);
        });

        this.dataset = [{
          label: `Total Earning of Gender`,
          data: data,
          backgroundColor: [
            '#ba1d1d',
            '#972383'
          ],
          hoverOffset: 4
        }];

        this.data = {
          labels: labels,
          datasets: this.dataset,
        }

        this.option = {
          data: this.data,
          type: 'pie'
        }

        this.genderEarningChart = new Chart("gender-earning",this.option);
      },
      error: (error) => {
        console.error(error);
      }
    })
  }

  getWorkingTimeEarning(){
    this.http.get<WorktimeEarningModel[]>("http://localhost:5003/api/dashboard/get-worktime-earning")
    .subscribe({
      next: (res: WorktimeEarningModel[]) => {
        let labels: string[] = [];
        let data: number[] = [];

        res.forEach(d => {
          labels.push(d.workTime);
          data.push(d.totalEarning);
        });

        this.dataset = [{
          label: `Working Time Earning`,
          data: data,
          backgroundColor: [
            '#ba1d1d',
            '#972383'
          ],
          hoverOffset: 4
        }];

        this.data = {
          labels: labels,
          datasets: this.dataset,
        }

        this.option = {
          data: this.data,
          type: 'pie'
        }

        this.workingTimeEarningChart = new Chart("working-time-earning",this.option);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  getProject(){
    this.http.get<ProjectModel[]>("http://localhost:5003/api/dashboard/get-projects")
    .subscribe({
      next: (res: ProjectModel[]) => {
        let labels: string[] = [];
        let data: number[] = [];
        let total: number = 0;
        res.forEach(p => {
          labels.push(p.projectName);
          data.push(p.budget);
          total+= p.budget;
        });

        this.dataset = [{
          label: `Projects (Total: ${total})`,
          data: data,
          backgroundColor: [
            'purple'
          ],
          borderWidth: 1,
          barPercentage: 0.5
        }];

        this.data = {
          labels: labels,
          datasets: this.dataset
        }

        this.option = {
          data: this.data,
          type: 'bar',
          options: {

          }
        }

        this.projectsChart = new Chart("projects",this.option);
      },
      error : (err) => {
        console.error(err);
      }
    });
  }

}
