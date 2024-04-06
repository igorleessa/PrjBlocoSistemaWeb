import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaBandaComponent } from './lista-banda.component';

describe('ListaBandaComponent', () => {
  let component: ListaBandaComponent;
  let fixture: ComponentFixture<ListaBandaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListaBandaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListaBandaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
