import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentSumComponent } from './current-sum.component';

describe('CurrentSumComponent', () => {
  let component: CurrentSumComponent;
  let fixture: ComponentFixture<CurrentSumComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurrentSumComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentSumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
