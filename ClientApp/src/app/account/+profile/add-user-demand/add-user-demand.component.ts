import { Component, OnInit, Input} from '@angular/core';
import Dataservice = require("../../../core/services/data.service");
import DataService = Dataservice.DataService;
import Profilemodels = require("../profile.models");
import IBook = Profilemodels.IBook;
import UserDemand = Profilemodels.UserDemand;


@Component({
  selector: 'appc-add-user-demand',
  templateUrl: './add-user-demand.component.html',
  styleUrls: ['./add-user-demand.component.scss']
})
export class AddUserDemandComponent implements OnInit {
    /**
     * id: number;

    UserEmail: string;

    Description: string;

    Price:string;

    BookId: number;
     */

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
        this.dataService.post('api/UserDemands?description='
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
        this.selectedBook = this.books.find(b => b.id == bookId);
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
