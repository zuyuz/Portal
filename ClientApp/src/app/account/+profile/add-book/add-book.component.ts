import { Component, OnInit } from '@angular/core';
import Controlbase = require("../../../shared/forms/controls/control-base");
import ControlBase = Controlbase.ControlBase;
import Controltextbox = require("../../../shared/forms/controls/control-textbox");
import ControlTextbox = Controltextbox.ControlTextbox;
import Profilemodels = require("../profile.models");
import IBook = Profilemodels.IBook;
import Dataservice = require("../../../core/services/data.service");
import DataService = Dataservice.DataService;

@Component({
  selector: 'appc-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.scss']
})
export class AddBookComponent implements OnInit {

    public controls: Array<ControlBase<string>> = [
        new ControlTextbox({
            key: 'title',
            label: 'Title',
            placeholder: 'Title',
            value: '',
            type: 'textbox',
            required: true,
            order: 1
        }),
        new ControlTextbox({
            key: 'author',
            label: 'Author',
            placeholder: 'Author',
            value: '',
            type: 'textbox',
            required: true,
            order: 2
        }),
        new ControlTextbox({
            key: 'country',
            label: 'Country',
            placeholder: 'Country',
            value: '',
            type: 'textbox',
            required: true,
            order: 3
        }),
        new ControlTextbox({
            key: 'language',
            label: 'Language',
            placeholder: 'Language',
            value: '',
            type: 'textbox',
            required: true,
            order: 4
        }),
        new ControlTextbox({
            key: 'genre',
            label: 'Genre',
            placeholder: 'Genre',
            value: '',
            type: 'textbox',
            required: true,
            order: 5
        }),
        new ControlTextbox({
            key: 'publisher',
            label: 'Publisher',
            placeholder: 'Publisher',
            value: '',
            type: 'textbox',
            required: true,
            order: 6
        })
    ];

    constructor(
        private dataService: DataService
    ) { }

    public ngOnInit() { }

    public save(model: IBook): void {
        //this.dataService.userInfo(model)
        //    .subscribe((res: UserInfoModel) => {
        //        this.ns.success(`Name changed to ${res.firstName} ${res.lastName}`);
        //    });
        this.dataService.post('api/Books', model).subscribe((result) => {

        });

    }

}
