import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductStorageComponent } from './product-storage.component';

describe('ProductStorageComponent', () => {
  let component: ProductStorageComponent;
  let fixture: ComponentFixture<ProductStorageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductStorageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductStorageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
