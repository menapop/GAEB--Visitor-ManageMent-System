import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlacklistuserComponent } from './blacklistuser.component';

describe('BlacklistuserComponent', () => {
  let component: BlacklistuserComponent;
  let fixture: ComponentFixture<BlacklistuserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlacklistuserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlacklistuserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
