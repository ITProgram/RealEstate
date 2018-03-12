import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule,NgForm } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

import { AgmCoreModule, MarkerManager, GoogleMapsAPIWrapper } from '@agm/core';

import { JwtModule, JwtHelperService } from '@auth0/angular-jwt';
import { HttpClientModule } from '@angular/common/http';

import { AuthService } from './components/auth/auth.service'
import { UserService } from './components/profile/user.service'
import { AdvertisementService } from './components/advertisement/advertisement.service'

import { AuthGuardService } from './components/auth/auth-guard.service'
import { AuthComponent } from './components/auth/auth.component'
import { AdvertisementComponent } from './components/advertisement/advertisement.component'
import { EditAdvertisementComponent } from './components/edit-advertisement/edit-advertisement.component'
import { CreateAdvertisementComponent } from './components/create-advertisement/create-advertisement.component'

import { HeaderComponent } from './components/header/header.component'
import { FooterComponent } from './components/footer/footer.component'
import { AdvertisementEditorComponent } from './components/advertisement-editor/advertisement-editor.component'
import { ProfileComponent } from './components/profile/profile.component'
import { LoginComponent } from './components/login/login.component'
import { RegistrationComponent } from './components/registration/registration.component'

import
{
    MatButtonModule, MatInputModule, MatSlideToggleModule, MatCardModule, MatToolbarModule, MatIconModule, MatSnackBarModule, MatExpansionModule,
    MatTableModule, MatPaginatorModule, MatSortModule, MatSelectModule, MatSliderModule, MatCheckboxModule,
    MatListModule

} from '@angular/material';
//import { FlexLayoutModule } from "@angular/flex-layout";
//import { AdvertisementCreateComponent } from './components/pages/advertisement-create/advertisement-create.component';
//import { AgmJsMarkerClustererModule } from '@agm/js-marker-clusterer'; 

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        AdvertisementComponent,
        AdvertisementEditorComponent,
        HeaderComponent,
        FooterComponent,
        ProfileComponent,
        AuthComponent,
        LoginComponent,
        RegistrationComponent,
        EditAdvertisementComponent,
        CreateAdvertisementComponent
        



        //  AdvertisementCreateComponent
    ],
    imports: [
        HttpClientModule,
        JwtModule.forRoot({
            config: {
                tokenGetter: () =>
                {
                    //alert('getting token'+localStorage.getItem('jwt'));
                    return sessionStorage.getItem('jwt');
                },
                skipWhenExpired: true
            }
        }),
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,

        AgmCoreModule.forRoot({
            apiKey: 'AIzaSyBugSIT0BgbqDqlxZyKtZsYkLht6Z5Zbi8',
            libraries: ["places"]
        }),
        //dAgmJsMarkerClustererModule,


        MatButtonModule, MatInputModule, MatSlideToggleModule, MatCardModule, MatToolbarModule,
        MatIconModule, MatSnackBarModule, MatExpansionModule, MatTableModule, MatPaginatorModule, MatSortModule,
        MatSelectModule, MatSliderModule, MatCheckboxModule,
        MatListModule,
        //FlexLayoutModule,



        //BrowserAnimationsModule

        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'advertisements/create', component: CreateAdvertisementComponent/*, canActivate: [AuthGuardService]*/ },
            { path: 'advertisements/:id/edit', component: EditAdvertisementComponent/*, canActivate: [AuthGuardService]*/ },

            { path: 'advertisements/:id', component: AdvertisementComponent },
            { path: 'profile', component: ProfileComponent, canActivate: [AuthGuardService] },
            { path: 'login', component: LoginComponent, canActivate: [AuthGuardService] },
            { path: 'registration', component: RegistrationComponent, canActivate: [AuthGuardService] }
            //,
            //{ path: '**', redirectTo: 'home' }
        ])

    ],
    providers: [MarkerManager,
        GoogleMapsAPIWrapper,
        UserService,
        AuthService,
       
        AdvertisementService,
        JwtHelperService,
        AuthGuardService]
})
export class AppModuleShared
{
}
