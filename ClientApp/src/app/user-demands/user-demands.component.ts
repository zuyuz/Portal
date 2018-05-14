import { Component, OnInit, Input } from '@angular/core';
import Profilemodels = require("../account/+profile/profile.models");
import UserDemand = Profilemodels.UserDemand;
import IBook = Profilemodels.IBook;
import Dataservice = require("../core/services/data.service");
import DataService = Dataservice.DataService;
import Accountservice = require("../core/services/account.service");
import AccountService = Accountservice.AccountService;

@Component({
  selector: 'appc-user-demands',
  templateUrl: './user-demands.component.html',
  styleUrls: ['./user-demands.component.scss']
})
export class UserDemandsComponent implements OnInit {

    @Input() demands: Array<UserDemand>;
    books: Array<IBook>;
    constructor(private dataService: DataService,
        private accountService: AccountService) {
        this.dataService = dataService;
        this.accountService = accountService;
    }

    ngOnInit() {
        this.dataService.get('api/Books').subscribe((book) => {
            this.books = book as Array<IBook>;

            this.dataService.get('api/UserDemands/UserDemands').subscribe((result) => {
                console.log(result);
                this.demands = result as Array<UserDemand>;
            });
        });
    }

    apply(event: UserDemand) {
        console.log(event);
        this.dataService.post('api/UserDemands/Contract?id=' + event.id).subscribe((result) => {
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
        return this.accountService.isLoggedIn;
    }

}
