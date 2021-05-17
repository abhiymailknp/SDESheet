import { TestBed } from '@angular/core/testing';

import { QuesService } from './ques.service';

describe('QuesService', () => {
  let service: QuesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(QuesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
