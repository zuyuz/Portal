import { YoutubeViewModel, Video } from './youtubeViewModel';
import { Component, OnInit, Input, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import { DataService } from '../core/services/data.service';

@Component({
  selector: 'appc-youtube-service',
  templateUrl: './youtube-service.component.html',
  styleUrls: ['./youtube-service.component.scss']
})
export class YoutubeServiceComponent implements OnChanges, OnInit {
  @Input() searchValue = '';
  @Input() youtubeId = 'Lt6PPiTTwbE';
  player: YT.Player;
  @Input() height = 500;

  @Input() width = 1000;
  searchResult: YoutubeViewModel;
  videos: Array<Video>;

  index = 0;
  constructor(
    private dataService: DataService
  ) {
  }
  ngOnChanges(changes: SimpleChanges) {
    const name: SimpleChange = changes.name;
    console.log('prev value: ', name.previousValue);
    console.log('got name: ', name.currentValue);
    this.youtubeId = name.currentValue.toUpperCase();
  }
  ngOnInit() {
  }
  onSearchChange(searchValue: string ) {
    this.searchValue = searchValue;
    console.log(searchValue);
  }
  savePlayer(player) {
    this.player = player;
    console.log('player instance', player);
  }
  onStateChange(event) {
    console.log('player state', event.data);
  }

  onUploadData(event) {
    this.getData();
    if (this.searchResult !== undefined) {
      this.videos = this.searchResult.videos;
    }
  }
  onVideoLoad(video: Video) {
    this.getData();
    this.youtubeId = video.id;
    this.player.loadVideoById(this.youtubeId);
  }
  getData() {
    this.dataService.get('api/youtube/search?searchText=' + this.searchValue).subscribe((searchResult) => {
      this.searchResult = searchResult as YoutubeViewModel;
      this.videos = this.searchResult.videos;
    });
    console.log(this.searchResult);
  }
}
