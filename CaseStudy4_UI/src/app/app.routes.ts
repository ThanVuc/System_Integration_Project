import { Routes } from '@angular/router';
import { CeoLayoutComponent } from './shares/ceo-layout/ceo-layout.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

export const routes: Routes = [
    {
        path: "",
        redirectTo: "dashboard" ,
        pathMatch: "full"
    },
    {
        path: "dashboard",
        component: CeoLayoutComponent,
        loadChildren: () => [
            {
                path: '',
                component: DashboardComponent
            }
        ]
    }
];
