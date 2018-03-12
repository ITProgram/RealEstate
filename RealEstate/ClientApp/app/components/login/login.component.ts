import { Component } from '@angular/core';
import { User } from '../profile/user'
import { AuthService } from '../auth/auth.service'
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Router } from '@angular/router';

import { MatSnackBar } from '@angular/material';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginComponent
{
    user: User = new User();
    constructor(
        private authService: AuthService,
        private router: Router,
        public snackBar: MatSnackBar)
    {

    }
    signIn(/*loginFeedback: HTMLDivElement, passwordFeedback: HTMLDivElement, errorResponse: HTMLDivElement*/)
    {
        this.authService.login(this.user.login, this.user.password)
            .subscribe(response =>
            {
                sessionStorage.setItem('jwt', response.headers.get('Authorization'));
                console.log(response.headers.get('Authorization'));
                //errorResponse.innerHTML = "";
                this.router.navigateByUrl('/home');
                this.snackBar.open("С возвращением!", null, { duration: 1000 });
            },
            error =>
            {
                if (error.status == 401)
                {

                    this.snackBar.open("Неверный пароль или логин, попробуйте снова", null, { duration: 1000 });
                    //  errorResponse.innerHTML = "Неверный пароль или логин";
                }
                else 
                {
                    this.snackBar.open(`Хмм, Странная ошибка ${error.status}. Попробуйте снова`, null, { duration: 1000 });

                }
            })
    }
}