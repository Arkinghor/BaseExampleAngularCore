
import { Component, Input, HostListener, EventEmitter, Output, Directive } from '@angular/core';
import { TripService } from '../../services/trip.service';
import { FormControl, FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { forEach } from '@angular/router/src/utils/collection';
import { Router } from '@angular/router';

import { TripComponent } from '../trip/trip.component';
import { Event } from '@angular/router/src/events';


@Component({
    selector: 'addtrips',
    templateUrl: './addtrips.component.html',
    styleUrls: ['./addtrips.component.css']
})
export class AddTripsComponent {

    trip: BaseExampleAngularCore.Model.ITrip;

    signupForm: FormGroup;

    selectedFile: any;

    @Output() onRefresh: EventEmitter<any> = new EventEmitter();

    assets: string[] = [];

    constructor(private tripService: TripService,
        private router: Router,
        private fb: FormBuilder) {


        this.selectedFile = null;

        this.signupForm = new FormGroup({
            HotelName: new FormControl('', [
                <any>Validators.required,
                <any>Validators.minLength(4)
            ]),
            Country: new FormControl(),
            Region: new FormControl(),
            Price: new FormControl(),
            Assets: this.fb.array([
                this.initAssets()
            ])
        })
    }

    removeAssets(i: number) {
        // add address to the list
        const control = <FormArray>this.signupForm.controls['Assets'];
        control.removeAt(i);
    }

    addAssets() {
        // add address to the list
        const control = <FormArray>this.signupForm.controls['Assets'];
        control.push(this.initAssets());
    }

    initAssets() {
        return this.fb.group({
            Asset: ['']
        });
    }

    onFileSelected(event:any) {
        this.selectedFile = event.target.files[0];
    }

    uploadFile() {
        const formData: FormData = new FormData();

        formData.append('image', this.selectedFile, this.selectedFile.name);

        this.tripService.upload(formData);
    }

    public onClickSubmit() {
        if (this.signupForm.valid) {
            var values = this.signupForm.value;

            for (let key in values.Assets) {
                this.assets.push(values.Assets[key].Asset);
            }


            this.trip = values;

            this.trip.Assets = this.assets;


            this.tripService.AddTrip(this.trip);

            this.uploadFile();


            this.tripService.refresh("refreshTrips");

        }
    }

}