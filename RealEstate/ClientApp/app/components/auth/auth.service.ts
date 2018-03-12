import { Injectable, Inject } from '@angular/core';
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';

import { JwtHelperService } from '@auth0/angular-jwt'

import { User } from '../profile/user';


import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
@Injectable()
export class AuthService
{
    private static user: User;

    constructor(
        private router: Router,
        private http: HttpClient,
        private jwtHelperService: JwtHelperService
    )
    {

    }
    public loggedIn()
    {
        try
        {
            const token: string = this.jwtHelperService.tokenGetter();

            if (!token)
            {
                return false
            }

            const tokenExpired: boolean = this.jwtHelperService.isTokenExpired(token)
            //alert("expired"+tokenExpired);
            return !tokenExpired
        } catch (Error)
        {
            //sessionStorage.removeItem('jwt');
            return false
        }
    }

    // getUsers(): Observable<User[]>
    //{
    //    return this.http.get<User[]>('/api/users')
    //}

    //public login(login: HTMLInputElement, password: HTMLInputElement): Promise<any>
    //{

    //    return new Promise((resolve, reject) =>
    //    {
    //        if ((login.value === "admin" && password.value === "admin")
    //            || (login.value === "admin" && password.value === "admin"))
    //        {
    //            AuthService.user = new User();
    //            AuthService.isLoggedIn = true;
    //            resolve();
    //        } else
    //        {
    //            reject();
    //        }
    //    });
    //}

    //public getUser(): User
    //{
    //    return AuthService.user;
    //}

    //public isLoggedIn(): boolean
    //{
    //    return AuthService.isLoggedIn;
    //}

    public logout()
    {
        this.router.navigate([""]);

        sessionStorage.removeItem('jwt');
    }
    public login(login: string, password: string): Observable<any>
    {
        return this.http.post('/api/sessions/', { login: login, password: password }, { observe: 'response' })
           
    }
    
}