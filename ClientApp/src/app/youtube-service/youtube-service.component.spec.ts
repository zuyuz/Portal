import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YoutubeServiceComponent } from './youtube-service.component';

describe('YoutubeServiceComponent', () => {
  let component: YoutubeServiceComponent;
  let fixture: ComponentFixture<YoutubeServiceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YoutubeServiceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YoutubeServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
