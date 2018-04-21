export class YoutubeViewModel
{
    public videos : Array<Video>
    public playlists : Array<Playlist>
    public channels : Array<Channel>
}

export class YoutubeElement
{
    public id : string;
    public name : string;
}

export class Video extends YoutubeElement
{

}
export class Playlist extends YoutubeElement
{

}
export class Channel extends YoutubeElement
{

}