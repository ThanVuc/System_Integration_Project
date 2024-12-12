import { Routes } from '@angular/router';
import { CeoLayoutComponent } from './shares/ceo-layout/ceo-layout.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EmployeesComponent } from './components/employees/employees.component';
import { EmployeeDetailComponent } from './components/employee-detail/employee-detail.component';

export const routes: Routes = [
    {
        path: "",
        redirectTo: "dashboard/analysis/total-earning" ,
        pathMatch: "full"
    },
    {
        path: "dashboard",
        component: CeoLayoutComponent,
        loadChildren: () => [
            {
                path: 'analysis/total-earning',
                component: DashboardComponent
            },
            {
                path: 'stake-holder/employees',
                component: EmployeesComponent
            },
            {
                path: 'stake-holder/employees/:id',
                component: EmployeeDetailComponent
            }
        ]
    }
];
