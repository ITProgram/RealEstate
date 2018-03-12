import { Component, Input, NgZone } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { Subscription } from 'rxjs/Subscription';
import { AdvertisementService } from '../advertisement/advertisement.service'
import { Advertisement } from './advertisement';
import { ActivatedRoute, ParamMap, Router, } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt'
import { AuthService } from '../auth/auth.service';

import { AgmMap, MapsAPILoader, GoogleMapsAPIWrapper, MarkerManager, AgmMarker, AgmInfoWindow } from '@agm/core';

@Component({
    selector: 'advertisement',
    templateUrl: './advertisement.component.html',
    styleUrls: ['./advertisement.component.css']
})

export class AdvertisementComponent
{
    advertisement: Advertisement = new Advertisement();
    editable: boolean;
    marker: AgmMarker=new AgmMarker(this.markerManager);
    zoom = 15;
    latitude = 53.902496;
    longitude = 27.561481;
    constructor(
        private mapsAPILoader: MapsAPILoader,
        private ngZone: NgZone,
        private markerManager: MarkerManager,

        private router: Router,
        private activatedRoute: ActivatedRoute,
        private advertisementService: AdvertisementService,
        private snackBar: MatSnackBar,
        private jwtHelperService: JwtHelperService,
        private authService: AuthService)
    {
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
                },
                error =>
                {
                    this.snackBar.open(`Хмм, Странная ошибка ${error.status}`, null, { duration: 1000 });
                })
        });

    }

    ngOnInit()
    {


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
    dragEnd($event: any)
    {
        this.latitude = $event.coords.lat;
        this.longitude = $event.coords.lng;
        this.marker.latitude = $event.coords.lat;
        this.marker.longitude = $event.coords.lng;

        //this.markerManager.updateMarkerPosition(marker);
        //this.markerCoordinates.longitude = $event.coords.lng;
        //this.markerCoordinates.latitude = $event.coords.lat;
        console.log(this.marker);
    }
   
}
