import { Injectable } from '@angular/core';
//import { AuthService } from '../auth/auth.service'
import { Router } from "@angular/router";
import { HttpClient , HttpResponse} from '@angular/common/http';


import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { User } from './user';



@Injectable()
export class UserService
{
    constructor(
        private router: Router,
        private http: HttpClient,
        //private authService = AuthService
    )
    {

       


    }

    public getUserById(id: number)
    {
        return this.http.get(`/api/users/${id}`, { observe: 'response' });
    }
    public deleteUser(id: number): Observable<any>
    {
        
        return this.http.delete(`/api/users/${id}`);
    }

    public updateUser(id: number, login: string, email: string, password: string):Observable<any>
    {
        return this.http.put(`/api/users/${id}`, { login: login, email: email, password: password }, { observe: 'response' });
    }
    public createUser(login: string, email: string, password: string): Observable<any>
    {
        return this.http.post('/api/users/', { login: login, email: email, password: password }, { observe: 'response' })

    }
}