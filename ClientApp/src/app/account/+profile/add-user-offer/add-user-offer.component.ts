import { Component, OnInit, Input } from '@angular/core';
import Profilemodels = require("../profile.models");
import IBook = Profilemodels.IBook;
import Dataservice = require("../../../core/services/data.service");
import DataService = Dataservice.DataService;
import UserDemand = Profilemodels.UserDemand;

@Component({
  selector: 'appc-add-user-offer',
  templateUrl: './add-user-offer.component.html',
  styleUrls: ['./add-user-offer.component.scss']
})
export class AddUserOfferComponent implements OnInit {

    @Input() selectedBook: IBook;

    @Input() books: Array<IBook>;
    @Input() price: string;
    @Input() comment: string;
    constructor(
        private dataService: DataService
    ) { }

    public ngOnInit() {
        this.dataService.get('api/Books/UserBooks').subscribe((result) => {
            this.books = result as Array<IBook>;
            this.selectedBook = this.books[0];
        });
    }

    public save(event): void {
        //this.dataService.userInfo(model)
        //    .subscribe((res: UserInfoModel) => {
        //        this.ns.success(`Name changed to ${res.firstName} ${res.lastName}`);
        //    });

        var model = new UserDemand();

        model.id = 4;
        model.description = this.comment;
        model.bookId = this.selectedBook.id;
        console.log(this.selectedBook);
        console.log(model);
        this.dataService.post('api/UserOffers?description='
            + this.comment
            + "&price="
            + this.price
            + "&bookId="
            + this.selectedBook.id).subscribe((result) => {

        });

    }
    public changeValue(event) {
        console.log(event);
    }
    onSelect(bookId) {
        console.log(this.books);
        var counter = 0;
        for (let i of this.books) {
            counter++;
            if (counter == bookId) {
                this.selectedBook = i;
            }
        }
    }
    onCommentChange(event) {
        this.comment = event;
        console.log(this.comment);
    }
    onPriceChange(event) {
        this.price = event;
        console.log(this.price);
    }

}
