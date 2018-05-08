import { Component, OnInit, OnChanges, SimpleChange, SimpleChanges } from '@angular/core';
import { DataService } from '../../../core/services/data.service';

@Component({
  selector: 'appc-favorite',
  templateUrl: './favorite.component.html',
  styleUrls: ['./favorite.component.scss']
})
export class FavoriteComponent implements OnChanges, OnInit {
  userFavorites: any;
  constructor(
    private dataService: DataService
  ) {
  }
  ngOnChanges(changes: SimpleChanges) {
    const name: SimpleChange = changes.name;
    console.log('prev value: ', name.previousValue);
    console.log('got name: ', name.currentValue);
  }
  ngOnInit() {
    this.getData();
  }
  getData() {
    this.dataService.get('api/youtube/userfavorite').subscribe((data) => {
      this.userFavorites = data;
      console.log(data);
    });
  }

  onRemovedPressed(event) {
    this.dataService.post('api/youtube/like?id=' + event.videoId + '&' + 'isFavorite=' + false).subscribe((data) => {
      this.userFavorites = data;
      console.log(this.userFavorites);
    });
  }


  onFavoritePressed(event) {
    console.log(event);
  }
}
