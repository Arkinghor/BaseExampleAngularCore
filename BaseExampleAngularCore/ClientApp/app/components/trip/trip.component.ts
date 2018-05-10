import { Component } from '@angular/core';
import { TripService } from '../../services/trip.service';


@Component({
    selector: 'trip',
    templateUrl: './trip.component.html',
    styleUrls: ['./trip.component.css']
})
export class TripComponent {

    trips: AngularCore.Model.ITrip[];

    test: any;
    
    constructor(private tripService: TripService) {

        var vm = this;

        this.tripService.getAllTrip().subscribe((trips: AngularCore.Model.ITrip[]) => {
                vm.trips = trips;
            })

    }

}
