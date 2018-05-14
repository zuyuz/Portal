import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookStoresComponent } from './book-stores.component';

describe('BookStoresComponent', () => {
  let component: BookStoresComponent;
  let fixture: ComponentFixture<BookStoresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookStoresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookStoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
