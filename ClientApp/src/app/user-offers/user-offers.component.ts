import { Component, OnInit, Input } from '@angular/core';
import Profilemodels = require("../account/+profile/profile.models");
import UserDemand = Profilemodels.UserDemand;
import IBook = Profilemodels.IBook;
import Dataservice = require("../core/services/data.service");
import DataService = Dataservice.DataService;
import Accountservice = require("../core/services/account.service");
import AccountService = Accountservice.AccountService;

@Component({
  selector: 'appc-user-offers',
  templateUrl: './user-offers.component.html',
  styleUrls: ['./user-offers.component.scss']
})
export class UserOffersComponent implements OnInit {

    @Input() offers: Array<UserDemand>;
    books: Array<IBook>;
    constructor(private dataService: DataService,
        private accountService: AccountService) {
        this.dataService = dataService;
        this.accountService = accountService;
    }

    ngOnInit() {
        this.dataService.get('api/Books').subscribe((book) => {
            this.books = book as Array<IBook>;

            this.dataService.get('api/UserOffers/UserOffers').subscribe((result) => {
                console.log(result);
                this.offers = result as Array<UserDemand>;
            });
        });
    }

    delete(event: UserDemand) {
        this.dataService.delete('api/UserOffers/' + event.id).subscribe((result) => {
        });
        this.dataService.get('api/UserOffers/UserOffers').subscribe((result) => {
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
    isLoggedIn() {
        console.log(this.accountService.isLoggedIn);
        return this.accountService.isLoggedIn;
    }

}
