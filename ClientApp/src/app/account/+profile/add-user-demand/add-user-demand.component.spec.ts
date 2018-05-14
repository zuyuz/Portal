import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUserDemandComponent } from './add-user-demand.component';

describe('AddUserDemandComponent', () => {
  let component: AddUserDemandComponent;
  let fixture: ComponentFixture<AddUserDemandComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddUserDemandComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUserDemandComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
