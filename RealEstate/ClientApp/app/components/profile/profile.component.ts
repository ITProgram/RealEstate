import { Component, ViewChild } from '@angular/core';
import { UserService } from './user.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from './user';
import { Router } from '@angular/router';
import
{
    MatSnackBar, MatSort, MatTableModule, MatPaginator,
    MatSortModule, MatTableDataSource
} from '@angular/material';
import { AuthService } from '../auth/auth.service'
import { Advertisement } from '../advertisement/advertisement';
import { AdvertisementService } from '../advertisement/advertisement.service';
import { AdvertisementParams } from '../advertisement/advertisement-params';


@Component({
    selector: 'profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.css']
})

export class ProfileComponent
{
    displayedColumns = ['id', 'address', 'cost', 'buttons'];
    

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;
    advertisements: Advertisement[] = [];
    dataSource: MatTableDataSource<Advertisement> = new MatTableDataSource(this.advertisements);
    user: User = new User();
    constructor(private userService: UserService,
        private jwtHelperService: JwtHelperService,
        private router: Router,
        private snackBar: MatSnackBar,
        private authService: AuthService,
        private advertisementService: AdvertisementService,

    )
    {

        
        //users: UserData[] = [];
        //for (let i = 1; i <= 100; i++) { users.push(createNewUser(i)); }

        

        userService.getUserById(jwtHelperService.decodeToken(jwtHelperService.tokenGetter()).userId).
            subscribe(response =>
            {
                this.user = response.body;
                console.log(response);
            });
        let search = new AdvertisementParams();
        search.userId = jwtHelperService.decodeToken(jwtHelperService.tokenGetter()).userId;
        advertisementService.getAdvertisements(
            search)
            .subscribe(response =>
            {
                console.log('get ads' + search.userId);
                console.log(search);
                this.advertisements = response.body;
                this.dataSource.data = this.advertisements;
            console.log(this.advertisements);

            },
            error =>
            {
                console.log(error);
                this.snackBar.open(`Хмм, Странная ошибка ${error.status}. Попробуйте снова`, null, { duration: 1000 });
            })

    }
    ngAfterViewInit()
    {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }
    applyFilter(filterValue: string)
    {
        filterValue = filterValue.trim(); // Remove whitespace
        filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
        this.dataSource.filter = filterValue;
    }
    updateProfile()
    {
        this.userService.updateUser(
            this.jwtHelperService.decodeToken(this.jwtHelperService.tokenGetter()).userId,
            this.user.login,
            this.user.email,
            this.user.password)
            .subscribe(response =>
            {
                this.user = response.body;
                this.snackBar.open("Изменения сохранены", null, { duration: 1000 });
            },
            error =>
            {
                console.log(error);
                this.snackBar.open(`Хмм, Странная ошибка ${error.status}. Попробуйте снова`, null, { duration: 1000 });
            })
    }
    updatePassword()
    {
        this.userService.updateUser(
            this.jwtHelperService.decodeToken(this.jwtHelperService.tokenGetter()).userId,
            null,
            null,
            this.user.password)
            .subscribe(response =>
            {
                this.user = response.body;
                this.authService.logout();
                this.snackBar.open("Пароль изменён", null, { duration: 1000 });

            },
            error =>
            {
                console.log(error);
                this.snackBar.open(`Хмм, Странная ошибка ${error.status}. Попробуйте снова`, null, { duration: 1000 });
            })
    }
    deleteUser()
    {
        this.userService.deleteUser(this.jwtHelperService.decodeToken(this.jwtHelperService.tokenGetter()).userId)
            .subscribe(response =>
            {
                this.authService.logout();
                this.snackBar.open("Профиль удален", null, { duration: 1000 });

            },
            error =>
            {
                console.log(error);
                this.snackBar.open(`Хмм, Странная ошибка ${error.status}. Попробуйте снова`, null, { duration: 1000 });


            })
    }
    deleteAdvertisement(id:number)
    {
        this.advertisementService.deleteAdvertisement(id)
            .subscribe(response =>
            {
                this.snackBar.open("Обхявление удален", null, { duration: 1000 });
                this.advertisementService.getAdvertisements();

            },
            error =>
            {
                console.log(error);
                this.snackBar.open(`Хмм, Странная ошибка ${error.status}. Попробуйте снова`, null, { duration: 1000 });


            })
    }
}

/** Builds and returns a new User. */
function createNewUser(id: number): UserData
{
    const name =
        NAMES[Math.round(Math.random() * (NAMES.length - 1))] + ' ' +
        NAMES[Math.round(Math.random() * (NAMES.length - 1))].charAt(0) + '.';

    return {
        id: id.toString(),
        name: name,
        progress: Math.round(Math.random() * 100).toString(),
        color: COLORS[Math.round(Math.random() * (COLORS.length - 1))]
    };
}

/** Constants used to fill up our data base. */
const COLORS = ['maroon', 'red', 'orange', 'yellow', 'olive', 'green', 'purple',
    'fuchsia', 'lime', 'teal', 'aqua', 'blue', 'navy', 'black', 'gray'];
const NAMES = ['Maia', 'Asher', 'Olivia', 'Atticus', 'Amelia', 'Jack',
    'Charlotte', 'Theodore', 'Isla', 'Oliver', 'Isabella', 'Jasper',
    'Cora', 'Levi', 'Violet', 'Arthur', 'Mia', 'Thomas', 'Elizabeth'];

export interface UserData
{
    id: string;
    name: string;
    progress: string;
    color: string;
}