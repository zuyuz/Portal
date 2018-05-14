import { Component, OnInit, Input } from '@angular/core';
import Profilemodels = require("../profile.models");
import IBook = Profilemodels.IBook;
import Dataservice = require("../../../core/services/data.service");
import DataService = Dataservice.DataService;

@Component({
  selector: 'appc-my-books',
  templateUrl: './my-books.component.html',
  styleUrls: ['./my-books.component.scss']
})
export class MyBooksComponent implements OnInit {

    @Input() books: Array<IBook>;
    constructor(private dataService: DataService) { this.dataService = dataService; }

    ngOnInit() {
        this.dataService.get('api/Books/UserBooks').subscribe((result) => {
            this.books = result as Array<IBook>;
            console.log(this.books);
        });
    }

    delete(event: IBook) {
        this.dataService.delete('api/Books/' + event.id).subscribe((result) => {
        });
        this.dataService.get('api/Books/UserBooks').subscribe((result) => {
            this.books = result as Array<IBook>;
            console.log(this.books);
        });
    }
    trackByFn(index, item) {
        console.log(index);
        return index;
    }
}
