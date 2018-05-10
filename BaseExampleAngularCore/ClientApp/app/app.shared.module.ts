import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { TripService } from "./services/trip.service"


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { TripComponent } from './components/trip/trip.component';
import { AddTripsComponent } from './components/addtrips/addtrips.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        TripComponent,
        AddTripsComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'trip', component: TripComponent },
            { path: 'addtrips', component: AddTripsComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ], providers: [TripService]
})
export class AppModuleShared {
}
