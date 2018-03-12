import { Injectable } from '@angular/core';
import { Router } from "@angular/router";
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';

import { Advertisement } from './advertisement';
import { AdvertisementParams } from './advertisement-params';


import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AdvertisementService
{
    private advertisements: Advertisement[] = [];

    constructor(
        private router: Router,
        private http: HttpClient,
        private jwtHelperService: JwtHelperService,
    )
    {
    }
    public getAdvertisements(
        searchParams?: AdvertisementParams
    ): Observable<any>
    {
        console.log(searchParams);
        let httpParams = new HttpParams();
        if (searchParams)
        {
            if (searchParams.userId) { httpParams= httpParams.append('userId', searchParams.userId.toString()) }

            if (searchParams.minBuidingYear) { httpParams = httpParams.append('minBuidingYear', searchParams.minBuidingYear.toString()) }
            if (searchParams.maxBuidingYear) { httpParams = httpParams.append('maxBuidingYear', searchParams.maxBuidingYear.toString()) }
            if (searchParams.minCost) { httpParams = httpParams.append('minCost', searchParams.minCost.toString()) }
            if (searchParams.maxCost) { httpParams = httpParams.append('maxCost', searchParams.maxCost.toString()) }
            if (searchParams.minFloor) { httpParams = httpParams.append('minFloor', searchParams.minFloor.toString()) }
            if (searchParams.maxFloor) { httpParams = httpParams.append('maxFloor', searchParams.maxFloor.toString()) }
            if (searchParams.minTotalArea) { httpParams = httpParams.append('minTotalArea', searchParams.minTotalArea.toString()) }
            if (searchParams.maxTotalArea) { httpParams = httpParams.append('maxTotalArea', searchParams.maxTotalArea.toString()) }
            if (searchParams.balcony && searchParams.balcony != undefined) { httpParams = httpParams.append('balcony', searchParams.balcony.toString()) }
            if (searchParams.minRooms) { httpParams = httpParams.append('minRooms', searchParams.minRooms.toString()) }
            if (searchParams.searchField) { httpParams = httpParams.append('searchField', searchParams.searchField) }
            if (searchParams.type) { httpParams = httpParams.append('type', searchParams.type.toString()) }

            console.log(searchParams);
        }
        return this.http.get('/api/advertisements', { params: httpParams, observe: 'response' });
    }
    public getAdvertisement(id: any): Observable<any>
    {
        return this.http.get(`/api/advertisements/${id}`, { observe: 'response' });

    }
    public createAdvertisement(
        advertisement: Advertisement
    ): Observable<any>
    {
        console.log(advertisement);
        return this.http.post('/api/advertisements', advertisement, { observe: 'response' })
    }
    public deleteAdvertisement(
        id: number
    ): Observable<any>
    {
        return this.http.delete(`/api/advertisements/${id}`, { observe: 'response' })
    }
    public updateAdvertisement(advertisement: Advertisement): Observable<any>
    {
        let httpParams = new HttpParams();
        return this.http.put(`/api/advertisements/${advertisement.id}`, advertisement, { observe: 'response' });
    }
}
