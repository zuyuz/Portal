import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { YoutubePlayerModule } from 'ngx-youtube-player';

import { ProfileComponent } from './profile.component';
import { ProfileService } from './profile.service';
import { UserInfoComponent } from './user-info/user-info.component';
import { UpdatePasswordComponent } from './update-password/update-password.component';
import { UserPhotoComponent } from './user-photo/user-photo.component';
import { OtherAccountsComponent } from './other-accounts/other-accounts.component';
import { TwoFactorAuthComponent } from './two-factor-auth/two-factor-auth.component';
import { EnableAuthenticatorComponent } from './two-factor-auth/enable-authenticator/enable-authenticator.component';
import { ResetAuthenticatorComponent } from './two-factor-auth/reset-authenticator/reset-authenticator.component';
import { RecoveryCodesComponent } from './two-factor-auth/recovery-codes/recovery-codes.component';
import { SharedModule } from '../../shared/shared.module';
import { FavoriteComponent } from './favorite/favorite.component';
import { AddAudioBookComponent } from './add-audio-book/add-audio-book.component';
import { AddBookComponent } from './add-book/add-book.component';
import { AddUserOfferComponent } from './add-user-offer/add-user-offer.component';
import { AddUserDemandComponent } from './add-user-demand/add-user-demand.component';
import { DropDownComponent } from './drop-down/drop-down.component';
import { MyBooksComponent } from './my-books/my-books.component';
import { MyDemandsComponent } from './my-demands/my-demands.component';
import { MyOffersComponent } from './my-offers/my-offers.component';
import { MyContractsComponent } from './my-contracts/my-contracts.component';
import { AssignedContractsComponent } from './assigned-contracts/assigned-contracts.component';

@NgModule({
    imports: [
        SharedModule,
        YoutubePlayerModule,
        RouterModule.forChild([
            {
                path: '', component: ProfileComponent, children: [
                    { path: '', redirectTo: 'userinfo', pathMatch: 'full' },
                    { path: 'userinfo', component: UserInfoComponent },
                    { path: 'updatepassword', component: UpdatePasswordComponent },
                    { path: 'userphoto', component: UserPhotoComponent },
                    { path: 'otheraccounts', component: OtherAccountsComponent },
                    { path: 'twofactorauth', component: TwoFactorAuthComponent },
                    { path: 'favorite', component: FavoriteComponent },
                    { path: 'addaudiobook', component: AddAudioBookComponent },
                    { path: 'addbook', component: AddBookComponent },
                    { path: 'mybooks', component: MyBooksComponent },
                    { path: 'adduserdemand', component: AddUserDemandComponent },
                    { path: 'adduseroffer', component: AddUserOfferComponent },
                    { path: 'mycontracts', component: MyContractsComponent },
                    { path: 'appliedcontracts', component: AssignedContractsComponent }
                ]
            },
        ])
    ],
    declarations: [
        ProfileComponent,
        UserInfoComponent,
        UpdatePasswordComponent,
        UserPhotoComponent,
        OtherAccountsComponent,
        TwoFactorAuthComponent,
        EnableAuthenticatorComponent,
        ResetAuthenticatorComponent,
        RecoveryCodesComponent,
        FavoriteComponent,
        AddAudioBookComponent,
        AddBookComponent,
        AddUserOfferComponent,
        AddUserDemandComponent,
        DropDownComponent,
        MyBooksComponent,
        MyDemandsComponent,
        MyOffersComponent,
        MyContractsComponent,
        AssignedContractsComponent,
    ],
    providers: [ProfileService]
})
export class ProfileModule { }
