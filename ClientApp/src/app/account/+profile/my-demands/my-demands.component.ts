import { Component, OnInit, Input } from '@angular/core';
import Profilemodels = require("../profile.models");
import Dataservice = require("../../../core/services/data.service");
import DataService = Dataservice.DataService;
import UserDemand = Profilemodels.UserDemand;
import IBook = Profilemodels.IBook;

@Component({
  selector: 'appc-my-demands',
  templateUrl: './my-demands.component.html',
  styleUrls: ['./my-demands.component.scss']
})
export class MyDemandsComponent implements OnInit {

    @Input() demands: Array<UserDemand>;
    books: Array<IBook>;
    constructor(private dataService: DataService) { this.dataService = dataService; }

    ngOnInit() {
        this.dataService.get('api/Books/UserBooks').subscribe((book) => {
            this.books = book as Array<IBook>;

            this.dataService.get('api/UserDemands/SpecificUserDemands').subscribe((result) => {
                console.log(result);
                this.demands = result as Array<UserDemand>;
            });
        });
    }

    apply(event: UserDemand) {
        this.dataService.delete('api/UserDemands/' + event.id).subscribe((result) => {
        });
        this.dataService.get('api/UserDemands/SpecificUserDemands').subscribe((result) => {
            this.demands = result as Array<UserDemand>;
            console.log(this.demands);
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
