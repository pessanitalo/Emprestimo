import { TestBed } from '@angular/core/testing';

import { EmprestimoService } from './emprestimo.service';

describe('EmprestimoService', () => {
  let service: EmprestimoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmprestimoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
