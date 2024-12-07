import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadComponent(){
            return import("./dashboard/dashboard.component")
            .then(dh => dh.DashboardComponent);
        }
    }
];
