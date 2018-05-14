import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAudioBookComponent } from './add-audio-book.component';

describe('AddAudioBookComponent', () => {
  let component: AddAudioBookComponent;
  let fixture: ComponentFixture<AddAudioBookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddAudioBookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAudioBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
