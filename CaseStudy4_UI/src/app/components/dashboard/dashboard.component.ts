import { DOCUMENT } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { AfterViewChecked, AfterViewInit, Component, inject, OnInit } from '@angular/core';
import { TimeUnit, Chart, registerables, scales, ChartConfiguration, DatasetChartOptions, DatasetController, DatasetControllerChartComponent, ChartData, ChartDataset, ChartItem } from 'chart.js';
import { ShareHolder, ShareHolderModel } from './models/share-holder-model';
import { map } from 'rxjs';
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
    this.document.addEventListener("DOMContentLoaded", () => {
      this.getShareHolder();
    });
  }

  showCharts(id: string, option: any){
    this.shareHolderEarningChart = new Chart(id,option);
  }

  total: number = 0;
  shareHolders: ShareHolder[] = [];

  shareHolderEarningChart!: Chart;

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

}
