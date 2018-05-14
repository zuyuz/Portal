import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUserOfferComponent } from './add-user-offer.component';

describe('AddUserOfferComponent', () => {
  let component: AddUserOfferComponent;
  let fixture: ComponentFixture<AddUserOfferComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddUserOfferComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUserOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
