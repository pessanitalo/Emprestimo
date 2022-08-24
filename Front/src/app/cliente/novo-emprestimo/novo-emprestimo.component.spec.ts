import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NovoEmprestimoComponent } from './novo-emprestimo.component';

describe('NovoEmprestimoComponent', () => {
  let component: NovoEmprestimoComponent;
  let fixture: ComponentFixture<NovoEmprestimoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NovoEmprestimoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NovoEmprestimoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
