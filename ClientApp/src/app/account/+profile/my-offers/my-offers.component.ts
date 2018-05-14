import { Component, OnInit, Input } from '@angular/core';
import Profilemodels = require("../profile.models");
import UserDemand = Profilemodels.UserDemand;
import IBook = Profilemodels.IBook;
import Dataservice = require("../../../core/services/data.service");
import DataService = Dataservice.DataService;

@Component({
  selector: 'appc-my-offers',
  templateUrl: './my-offers.component.html',
  styleUrls: ['./my-offers.component.scss']
})
export class MyOffersComponent implements OnInit {

    @Input() offers: Array<UserDemand>;
    books: Array<IBook>;
    constructor(private dataService: DataService) { this.dataService = dataService; }

    ngOnInit() {
        this.dataService.get('api/Books/UserBooks').subscribe((book) => {
            this.books = book as Array<IBook>;

            this.dataService.get('api/UserOffers/SpecificUserOffers').subscribe((result) => {
                console.log(result);
                this.offers = result as Array<UserDemand>;
            });
        });
    }

    delete(event: UserDemand) {
        this.dataService.delete('api/UserOffers/' + event.id).subscribe((result) => {
        });
        this.dataService.get('api/UserOffers/SpecificUserOffers').subscribe((result) => {
            this.offers = result as Array<UserDemand>;
            console.log(this.offers);
        });
    }
    trackByFn(index, item) {
        return index;
    }

    getBookName(bookId): string {
        console.log(bookId);
        return this.books.find(b => b.id == bookId).title;
    }

}
