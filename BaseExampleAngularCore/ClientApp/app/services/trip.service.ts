import { Injectable } from "@angular/core";
import { Http } from '@angular/http'; 
import { Observable } from "rxjs/Observable";


export interface ITripService {
    getAllTrip(): Observable<AngularCore.Model.ITrip[]>

    headers: Headers;

    getTripToEdit(): any//Observable<AngularCore.Model.ITrip[]>
}


@Injectable()


export class TripService implements ITripService{

    headers: Headers;


    constructor(private http: Http) {

    }

    getTripToEdit() {
        return 'test';
        //return this.http.get('http://localhost:55980/api/edit/GetTripsForEdit').subscribe((res: Response) => {
        //    return <AngularCore.Model.ITrip[]>res.json()
        //});
    } 

    getAllTrip(): Observable<any> {
        return this.http.get(`http://localhost:53346/api/trips/GetTrips`);
    }

}

