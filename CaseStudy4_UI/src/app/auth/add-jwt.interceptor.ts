import { DOCUMENT } from '@angular/common';
import { HttpContext, HttpContextToken, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';

export const addJwtInterceptor: HttpInterceptorFn = (req, next) => {
  if (req.context.get(IS_PUBLIC)){
    return next(req);
  }

  let accessToken = localStorage.getItem("jwtToken");
  if (accessToken){
    return next(req.clone({
      headers: req.headers.set('Authorization',`Bearer ${accessToken}`)
    }));
  }
  return next(req);
};

export const IS_PUBLIC = new HttpContextToken(() => false);