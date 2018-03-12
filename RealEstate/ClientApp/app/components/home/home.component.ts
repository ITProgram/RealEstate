import { Component, ElementRef, NgZone, OnInit, ViewChild, Inject } from '@angular/core';
import { FormControl } from "@angular/forms";
import { AgmMap, MapsAPILoader, GoogleMapsAPIWrapper, MarkerManager, AgmMarker, AgmInfoWindow } from '@agm/core';
import { AdvertisementService } from '../advertisement/advertisement.service'
import { PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser, isPlatformServer } from '@angular/common';
import { Advertisement } from '../advertisement/advertisement';
import { AdvertisementParams } from '../advertisement/advertisement-params';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'],
})

export class HomeComponent implements OnInit
{
    advertisementTypes: string[] =
        [
            "Продажа/Аренда",
            "Продажа",
            "Аренда"
        ];
    public infoWindow: AgmInfoWindow;
    public latitude: number;
    public longitude: number;
    public searchControl: FormControl;
    public zoom: number;
    public formatted_address: string;
    public count: number;
    lastOpen: AgmInfoWindow;
    public advertisements: Advertisement[] = [];
    public searchParams: AdvertisementParams = new AdvertisementParams;
    //markers1: marker[] = [
    //    {
    //        latitude: 53.902496,
    //        longitude: 27.561481,
    //        label: 'Map A',
    //        draggable: true,
    //        iconUrl: 'http://maps.google.com/mapfiles/ms/icons/green.png'
    //    }//,
    //{
    //    latitude: 51.373858,
    //    longitude: 7.215982,
    //    label: 'Map B',
    //    draggable: false,
    //    iconUrl: 'http://maps.google.com/mapfiles/ms/icons/red.png'
    //},
    //{
    //    latitude: 51.723858,
    //    longitude: 7.895982,
    //    label: 'Map C',
    //    draggable: true,
    //    iconUrl: 'http://maps.google.com/mapfiles/ms/icons/green.png'
    //}
    //];
    markers: AgmMarker[];
    constructor(
        private mapsAPILoader: MapsAPILoader,
        private ngZone: NgZone,
        private markerManager: MarkerManager,
        private advertisementService: AdvertisementService,
        @Inject(PLATFORM_ID) private platformId: Object
    )
    {
        this.searchParams.type = '0';
        this.zoom = 12;
        this.latitude = 53.902496;
        this.longitude = 27.561481;
        this.markers = [];
        this.count = 0;
    }

    ngOnInit()
    {
        if (isPlatformBrowser(this.platformId))
        {
            this.advertisementService.getAdvertisements().
                subscribe(response =>
                {
                    console.log(response.body);
                    this.advertisements = response.body;
                },
                error =>
                {
                    console.log("error get all ads");
                });
        }
    }
    search()
    {
        if (isPlatformBrowser(this.platformId))
        {

            this.advertisementService.getAdvertisements(this.searchParams).
                subscribe(response =>
                {

                    console.log(response.body);
                    this.advertisements.splice(0, this.advertisements.length);
                    this.advertisements = response.body;
                    //for (let i = 0; i < this.advertisements.length; i++)
                    //{
                    //    let m: AgmMarker = new AgmMarker(this.markerManager);
                    //    m.latitude = this.advertisements[i].latitude;
                    //    m.longitude = this.advertisements[i].longitude;
                    //    //m.draggable = true;
                    //    this.markers.push(m);
                    //}
                    //console.log(this.markers);
                },
                error =>
                {
                    console.log("error get all ads filter");
                });
        }
    }
    private setCurrentPosition()
    {
        if ("geolocation" in navigator)
        {
            navigator.geolocation.getCurrentPosition((position) =>
            {
                this.latitude = position.coords.latitude;
                this.longitude = position.coords.longitude;
                //this.zoom = 14;
            });
        }
    }
    clickedMarker(infoWindow: AgmInfoWindow)
    {
        if (this.lastOpen != null)
        {
            this.lastOpen.close();
        }

        this.lastOpen = infoWindow;

        infoWindow.open();
    }
    mouseOver(infoWindow: AgmInfoWindow)
    {
        this.clickedMarker(infoWindow);

    }
    mapClicked($event: any)
    {
        //this._markerManager.prototype.addMarker(new < google.maps.Marker())

        //this.setCurrentPosition();
        //this.markers.push({
        //    latitude: $event.coords.lat,
        //    longitude: $event.coords.lng,
        //    draggable:true
        //});

        console.log($event.coords.lat, $event.coords.lng);
    }
    dragEnd($event: any, marker: AgmMarker, i: number)
    {
        this.latitude = $event.coords.lat;
        this.longitude = $event.coords.lng;
        this.markers[i].latitude = $event.coords.lat;
        this.markers[i].longitude = $event.coords.lng;

        //this.markerManager.updateMarkerPosition(marker);
        //this.markerCoordinates.longitude = $event.coords.lng;
        //this.markerCoordinates.latitude = $event.coords.lat;
        console.log(this.markers);
    }
    concatAddress(advertisement:Advertisement): string
    {
        let address: string[] = [];

        if (advertisement.city) address.push(advertisement.city);
        if (advertisement.street) address.push(advertisement.street);
        if (advertisement.housing) address.push(advertisement.housing)
        if (advertisement.house) address.push(advertisement.house.toString())
        if (advertisement.apartment) address.push(advertisement.apartment.toString())

        return address.join(', ');
    }
}

interface marker
{

    latitude: number;
    longitude: number;
    label?: string;
    draggable: boolean;
    iconUrl?: string;
}
interface searchParams
{
     description: string;
    minBuidingYear?: number;
    maxBuidingYear?: number;
    minCost?: number;
    maxCost?: number;
    minFloor?: number;
    maxFloor?: number;
    minTotalArea?: number;
    maxTotalArea?: number;
    balcony?: boolean
    minRooms?: number
    searchField?: string
    type?: string
   
}