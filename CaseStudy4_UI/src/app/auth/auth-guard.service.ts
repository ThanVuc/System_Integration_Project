import { DOCUMENT } from '@angular/common';
import { inject, Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, GuardResult, MaybeAsync, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  document = inject(DOCUMENT);
  router = inject(Router);
  constructor() { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (this.document.defaultView?.localStorage){
      var jwtToken = this.document.defaultView?.localStorage.getItem("jwtToken");
      if (jwtToken == null){
        this.router.navigate(["/login"]);
        return false;
      }
      return true;
    }
    return false;
  }
}
