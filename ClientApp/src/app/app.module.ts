import { BrowserModule, BrowserTransferStateModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { ServiceWorkerModule } from '@angular/service-worker';
import { OAuthModule } from 'angular-oauth2-oidc';
import { PrebootModule } from 'preboot';
import { CoreModule } from './core/core.module';

import { environment } from '../environments/environment';

import { YoutubePlayerModule } from 'ngx-youtube-player';
// Components
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AppService } from './app.service';
import { YoutubeServiceComponent } from './youtube-service/youtube-service.component';

import {VgCoreModule} from 'videogular2/core';
import {VgControlsModule} from 'videogular2/controls';
import {VgOverlayPlayModule} from 'videogular2/overlay-play';
import {VgBufferingModule} from 'videogular2/buffering';
import { BookStoresComponent } from './book-stores/book-stores.component';
import { BooksComponent } from './books/books.component';
import { UserOffersComponent } from './user-offers/user-offers.component';
import { UserDemandsComponent } from './user-demands/user-demands.component';

export function appServiceFactory(appService: AppService): Function {
  return () => appService.getAppData();
}
@NgModule({
  declarations: [
    // Components
    AppComponent,
    HomeComponent,
    YoutubeServiceComponent,
    BookStoresComponent,
    BooksComponent,
    UserOffersComponent,
    UserDemandsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    PrebootModule.withConfig({ appRoot: 'appc-root' }),
    BrowserAnimationsModule,
    BrowserTransferStateModule,
    YoutubePlayerModule,
    VgCoreModule,
    VgControlsModule,
    VgOverlayPlayModule,
    VgBufferingModule,
    CoreModule.forRoot(),
    OAuthModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', data: { state: 'home' } },
      { path: 'YoutubeService', component: YoutubeServiceComponent, pathMatch: 'full', data: { state: 'YoutubeService' } },
        { path: 'BookStores', component: BookStoresComponent, pathMatch: 'full', data: { state: 'BookStores' } },
        { path: 'UserOffers', component: UserOffersComponent, pathMatch: 'full', data: { state: 'UserOffers' } },
        { path: 'UserDemands', component: UserDemandsComponent, pathMatch: 'full', data: { state: 'UserDemands' } },
        { path: 'Books', component: BooksComponent, pathMatch: 'full', data: { state: 'Books' } },
      { path: 'login', loadChildren: './account/+login/login.module#LoginModule' },
      { path: 'register', loadChildren: './account/+register/register.module#RegisterModule' },
      { path: 'createaccount', loadChildren: './account/+create/create.module#CreateAccountModule' },
      { path: 'profile', loadChildren: './account/+profile/profile.module#ProfileModule' },
      { path: 'chat', loadChildren: './+chat/chat.module#ChatModule' }
    ], { initialNavigation: 'enabled' }),
    ServiceWorkerModule.register('/ngsw-worker.js', { enabled: environment.production }),
  ],
  providers: [
    AppService,
    { provide: APP_INITIALIZER, useFactory: appServiceFactory, deps: [AppService], multi: true }
  ],
  exports: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
