import { Injectable, Inject } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';


import { PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser, isPlatformServer } from '@angular/common';
import { Observable } from 'rxjs/Observable';




@Injectable()
export class AuthGuardService implements CanActivate
{

    constructor(
        @Inject(PLATFORM_ID) private platformId: Object,
        private authService: AuthService,
        private router: Router,
    ) { }

    public canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean
    {
        if (isPlatformBrowser(this.platformId))
        {

            if (this.authService.loggedIn())
            {
                //alert(state.url);
                if (state.url === "/login" || state.url === "/registration")
                {
                    //alert("войден");
                    this.router.navigateByUrl('/home');
                    return false;
                }
                //alert('true returned'); 

                return true;
            } else
            {
                //alert('false returned');
                sessionStorage.removeItem('jwt');
                if (state.url === "/login" || state.url === "/registration")
                {
                    //alert("не войден");
                    return true;
                }

                this.router.navigateByUrl('/home');
                return false;
            }
        }
    }

}