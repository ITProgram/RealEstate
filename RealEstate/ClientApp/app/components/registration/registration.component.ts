import { Component } from '@angular/core';
import { User } from '../profile/user'
import { UserService } from '../profile/user.service'
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';


@Component({
    selector: 'registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.css']
})

export class RegistrationComponent
{
    user: User = new User();
    constructor(
        private userService: UserService,
        private router: Router,
     public snackBar: MatSnackBar)
    {

    }
    registration(
        loginFeedback: HTMLDivElement,
        emailFeedback: HTMLDivElement,
        passwordFeedback: HTMLDivElement,
        errorResponse: HTMLDivElement)
    {
        this.userService.createUser(this.user.login, this.user.email, this.user.password)
            .subscribe(response =>
            {
                this.router.navigateByUrl('/login');
                this.snackBar.open("Регистрация прошла успешно!", null, { duration: 1000 });
            },
            error =>
            {
                console.log(error);
                this.snackBar.open(`Ошибка ${error.status}. Попробуйте снова`, null, { duration: 1000 });
                //errorResponse.innerHTML = "Неверные данные";

            })
    }
}