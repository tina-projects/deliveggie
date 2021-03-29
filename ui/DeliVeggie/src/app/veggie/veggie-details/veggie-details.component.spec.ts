import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VeggieDetailsComponent } from './veggie-details.component';

describe('VeggieDetailsComponent', () => {
  let component: VeggieDetailsComponent;
  let fixture: ComponentFixture<VeggieDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VeggieDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VeggieDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
