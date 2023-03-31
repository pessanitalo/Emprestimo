import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NovoClienteComponent } from './novo-cliente.component';

describe('NovoClienteComponent', () => {
  let component: NovoClienteComponent;
  let fixture: ComponentFixture<NovoClienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NovoClienteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NovoClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
