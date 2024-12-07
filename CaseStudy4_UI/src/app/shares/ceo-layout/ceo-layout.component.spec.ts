import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CeoLayoutComponent } from './ceo-layout.component';

describe('CeoLayoutComponent', () => {
  let component: CeoLayoutComponent;
  let fixture: ComponentFixture<CeoLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CeoLayoutComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CeoLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
