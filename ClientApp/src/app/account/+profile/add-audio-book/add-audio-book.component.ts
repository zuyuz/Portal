import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../../../core/services/data.service';

@Component({
  selector: 'appc-add-audio-book',
  templateUrl: './add-audio-book.component.html',
  styleUrls: ['./add-audio-book.component.scss']
})
export class AddAudioBookComponent implements OnInit {
  @Input() url;
  constructor(
    private dataService: DataService) { }

  ngOnInit() {
  }
  onClick(event) {
    this.dataService.post('api/ExternalResources?url=' + this.url).subscribe((searchResult) => {
    });
  }
}
