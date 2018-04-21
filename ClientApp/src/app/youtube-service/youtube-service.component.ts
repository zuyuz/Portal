import { YoutubeViewModel } from './youtubeViewModel';
import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../core/services/data.service';

@Component({
  selector: 'appc-youtube-service',
  templateUrl: './youtube-service.component.html',
  styleUrls: ['./youtube-service.component.scss']
})
export class YoutubeServiceComponent implements OnInit {
  @Input() youtubeId: string;
  searchResult : YoutubeViewModel
  constructor(
    private dataService: DataService
) { }

  ngOnInit() {
  }

  player: YT.Player;
  @Input() id: string = 'Lt6PPiTTwbE';
  @Input() height = 500;

  @Input() width = 1000;
	savePlayer (player) {
    this.player = player;
    console.log('player instance', player)
	}
  onStateChange(event){
    console.log('player state', event.data);
  }

  onClick(event){
    this.getData();
    if (this.searchResult.videos.length > 5)
    {
      this.player.loadVideoById(this.searchResult.videos[4].id);
    }
  }

  getData() {
    this.dataService.get('api/youtube/search').subscribe((searchResult) => {
      this.searchResult = searchResult as YoutubeViewModel;
  });
  console.log(this.searchResult);
  }
}
