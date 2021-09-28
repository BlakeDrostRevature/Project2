import { TestBed } from '@angular/core/testing';

import { SmokeappService } from './smokeapp.service';

describe('SmokeappService', () => {
  let service: SmokeappService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SmokeappService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
