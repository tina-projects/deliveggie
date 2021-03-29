import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VeggieListComponent } from './veggie-list.component';

describe('VeggieListComponent', () => {
  let component: VeggieListComponent;
  let fixture: ComponentFixture<VeggieListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VeggieListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VeggieListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
