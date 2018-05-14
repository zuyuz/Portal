import { Component, OnInit, Input } from '@angular/core';
import Dataservice = require("../core/services/data.service");
import DataService = Dataservice.DataService;
import Profilemodels = require("../account/+profile/profile.models");
import IBook = Profilemodels.IBook;

@Component({
    selector: 'appc-books',
    templateUrl: './books.component.html',
    styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {
    @Input() books : Array<IBook>;
    constructor(private dataService: DataService) { this.dataService = dataService; }

    ngOnInit() {
        this.dataService.get('api/Books').subscribe((result) => {
            this.books = result as Array<IBook>;
            console.log(this.books);
        });
    }

}
