import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FavoritarComponent } from './favoritar.component';

describe('FavoritarComponent', () => {
  let component: FavoritarComponent;
  let fixture: ComponentFixture<FavoritarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FavoritarComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FavoritarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
