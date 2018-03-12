import { Component, Input, NgZone } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { Subscription } from 'rxjs/Subscription';
import { AdvertisementService } from '../advertisement/advertisement.service'
import { Advertisement } from '../advertisement/advertisement';
import { ActivatedRoute, ParamMap, Router, } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt'
import { AuthService } from '../auth/auth.service';
import { AgmMap, MapsAPILoader, GoogleMapsAPIWrapper, MarkerManager, AgmMarker, AgmInfoWindow } from '@agm/core';


@Component({
    selector: 'advertisement-editor',
    templateUrl: './advertisement-editor.component.html',
    styleUrls: ['./advertisement-editor.component.css']
})
export class AdvertisementEditorComponent
{
    marker: AgmMarker = new AgmMarker(this.markerManager);
    zoom = 15;
    latitude = 53.902496;
    longitude = 27.561481;

    @Input() isEditMode: boolean;
    @Input() isCreateMode: boolean;
    advertisement: Advertisement = new Advertisement();
    editable: boolean;
    constructor(
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private advertisementService: AdvertisementService,
        private snackBar: MatSnackBar,
        private jwtHelperService: JwtHelperService,
        private authService: AuthService,
        private mapsAPILoader: MapsAPILoader,
        private ngZone: NgZone,
        private markerManager: MarkerManager,)
    {
        this.marker.draggable = true;

    }
    ngOnInit()
    {
        if (this.isEditMode)
            this.activatedRoute.params.subscribe(params =>
            {
                this.advertisementService.getAdvertisement(params["id"])
                    .subscribe(response =>
                    {
                        console.log('resonse:');
                        console.log(response.body);
                        this.advertisement = response.body;
                        this.marker.latitude = this.advertisement.latitude;
                        this.marker.longitude = this.advertisement.longitude;
                        this.latitude = this.marker.latitude;
                        this.longitude = this.marker.longitude;
                        this.marker.draggable = true;
                        //this.advertisement.type = '1';
                        //this.advertisement.userId = 10;//TODO delete it
                        //this.advertisement.city = "MInsk";
                        //this.advertisement.apartment = 34;
                        //if (this.authService.loggedIn()
                        //    && (this.jwtHelperService.decodeToken(this.jwtHelperService.tokenGetter()).userId == this.advertisement.userId))
                        //{
                        //    this.editable = true;
                        //}
                        //else
                        //{
                        //    this.editable = false;
                        //}
                    },
                    error =>
                    {
                        this.snackBar.open(`Хмм, Странная ошибка ${error.status}`, null, { duration: 1000 });
                        console.log('editsble' + this.editable);
                    })
            });
        else
        {
            this.marker.latitude = this.latitude;
            this.marker.longitude = this.longitude;
            this.latitude = this.marker.latitude;
            this.longitude = this.marker.longitude;
        }
    }
    concatAddress(): string
    {
        let address: string[] = [];

        if (this.advertisement.city) address.push(this.advertisement.city);
        if (this.advertisement.street) address.push(this.advertisement.street);
        if (this.advertisement.housing) address.push(this.advertisement.housing)
        if (this.advertisement.house) address.push(this.advertisement.house.toString())
        if (this.advertisement.apartment) address.push(this.advertisement.apartment.toString())

        return address.join(', ');
    }
    createAdvertisement()
    {
        this.advertisementService.createAdvertisement(this.advertisement)
            .subscribe(response =>
            {
                
                this.router.navigateByUrl('/profile');
                this.snackBar.open("Объявление добавлено успешно!", null, { duration: 1000 });
            },
            error =>
            {
                console.log(error);
                this.snackBar.open(`Ошибка ${error.status}. Попробуйте снова`, null, { duration: 1000 });
                //errorResponse.innerHTML = "Неверные данные";

            })
    }
    updateAdvertisement()
    {
        this.advertisementService.updateAdvertisement(this.advertisement)
            .subscribe(response =>
            {
                
                this.router.navigateByUrl('/profile');
                this.snackBar.open("Объявление изменено  успешно!", null, { duration: 1000 });
            },
            error =>
            {
                console.log(error);
                this.snackBar.open(`Ошибка ${error.status}. Попробуйте снова`, null, { duration: 1000 });
            })
    }
    dragEnd($event: any)
    {
        this.latitude = $event.coords.lat;
        this.longitude = $event.coords.lng;
        this.marker.latitude = $event.coords.lat;
        this.marker.longitude = $event.coords.lng;
        this.advertisement.latitude = $event.coords.lat;
        this.advertisement.longitude = $event.coords.lng;
        //this.markerManager.updateMarkerPosition(marker);
        //this.markerCoordinates.longitude = $event.coords.lng;
        //this.markerCoordinates.latitude = $event.coords.lat;
        console.log(this.marker);
    }
}