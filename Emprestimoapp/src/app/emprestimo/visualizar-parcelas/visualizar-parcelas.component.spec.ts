import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarParcelasComponent } from './visualizar-parcelas.component';

describe('VisualizarParcelasComponent', () => {
  let component: VisualizarParcelasComponent;
  let fixture: ComponentFixture<VisualizarParcelasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarParcelasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarParcelasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
