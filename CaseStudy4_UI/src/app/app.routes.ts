import { Routes } from '@angular/router';
import { CeoLayoutComponent } from './shares/ceo-layout/ceo-layout.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EmployeesComponent } from './components/employees/employees.component';
import { EmployeeDetailComponent } from './components/employee-detail/employee-detail.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './auth/auth-guard.service';

export const routes: Routes = [
    {
        path: "",
        redirectTo: "dashboard/analysis/total-earning" ,
        pathMatch: "full"
    },
    {
        path: "dashboard",
        component: CeoLayoutComponent,
        canActivate: [AuthGuard],
        loadChildren: () => [
            {
                path: 'analysis/total-earning',
                component: DashboardComponent,
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
    },
    {
        path: "login",
        component: LoginComponent
    }
];
