import { Component, OnInit, Input } from '@angular/core';
import Profilemodels = require("../profile.models");
import IBook = Profilemodels.IBook;
import Dataservice = require("../../../core/services/data.service");
import DataService = Dataservice.DataService;
import UserDemand = Profilemodels.UserDemand;
import Contracts = Profilemodels.Contracts;

@Component({
  selector: 'appc-my-contracts',
  templateUrl: './my-contracts.component.html',
  styleUrls: ['./my-contracts.component.scss']
})
export class MyContractsComponent implements OnInit {

    @Input() contracts: Array<Contracts>;
    books: Array<IBook>;
    constructor(private dataService: DataService) { this.dataService = dataService; }

    ngOnInit() {
        this.dataService.get('api/Books/UserBooks').subscribe((book) => {
            this.books = book as Array<IBook>;

            this.dataService.get('api/UserDemands/ContractsByOwner').subscribe((result) => {
                console.log(result);
                this.contracts = result as Array<Contracts>;
            });
        });
    }

    apply(event: UserDemand) {
        this.dataService.get('api/UserDemands/ContractsByOwner').subscribe((result) => {
            this.contracts = result as Array<Contracts>;
            console.log(this.contracts);
        });
    }
    trackByFn(index, item) {
        return index;
    }

    getBookName(bookId): string {
        console.log(bookId);
        return this.books.find(b => b.id == bookId).title;
    }

    selectContract(contract: Contracts) {
        contract.isAllowed = true;
        //this.dataService.put('api/UserDemands/Contract?isAllowed=' + true, contract).subscribe((result) => {
        //});
    }

}
