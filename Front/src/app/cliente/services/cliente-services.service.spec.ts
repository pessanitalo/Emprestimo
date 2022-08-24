import { TestBed } from '@angular/core/testing';

import { ClienteServicesService } from './cliente-services.service';

describe('ClienteServicesService', () => {
  let service: ClienteServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClienteServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
