import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignedContractsComponent } from './assigned-contracts.component';

describe('AssignedContractsComponent', () => {
  let component: AssignedContractsComponent;
  let fixture: ComponentFixture<AssignedContractsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssignedContractsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignedContractsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
