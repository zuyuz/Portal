import { Component, OnInit } from '@angular/core';

import { UserInfoModel } from '../profile.models';
import { ProfileService } from '../profile.service';
import { ControlBase } from '../../../shared/forms/controls/control-base';
import { ControlTextbox } from '../../../shared/forms/controls/control-textbox';
import { NotificationsService } from '../../../core/simple-notifications/simple-notifications.module';

@Component({
  selector: 'appc-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements OnInit {
  public controls: Array<ControlBase<string>> = [
    new ControlTextbox({
      key: 'firstName',
      label: 'Ім\'я',
      placeholder: 'Ім\'я',
      value: '',
      type: 'textbox',
      required: true,
      order: 1
    }),
    new ControlTextbox({
      key: 'lastName',
      label: 'Прізвище',
      placeholder: 'Прізвище',
      value: '',
      type: 'textbox',
      required: true,
      order: 2
    }),
    new ControlTextbox({
      key: 'phoneNumber',
      label: 'Номер телефону',
      placeholder: 'Номер телефону',
      value: '',
      type: 'textbox',
      required: false,
      order: 3
    })
  ];

  constructor(
    public profileService: ProfileService,
    private ns: NotificationsService
  ) { }

  public ngOnInit() { }

  public save(model: UserInfoModel): void {
    this.profileService.userInfo(model)
      .subscribe((res: UserInfoModel) => {
        this.ns.success(`Name changed to ${res.firstName} ${res.lastName}`);
      });

  }

}
