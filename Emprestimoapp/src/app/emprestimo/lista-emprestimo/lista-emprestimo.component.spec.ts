import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaEmprestimoComponent } from './lista-emprestimo.component';

describe('ListaEmprestimoComponent', () => {
  let component: ListaEmprestimoComponent;
  let fixture: ComponentFixture<ListaEmprestimoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaEmprestimoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaEmprestimoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
