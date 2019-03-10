import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserDropDownComponent } from './user-drop-down.component';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { UserService } from '../services/user-service/user.service';
import { MockUserService } from './MockUserService';

;

describe('UserDropDownComponent', () => {
  let component: UserDropDownComponent;
  let fixture: ComponentFixture<UserDropDownComponent>;
  let userService : UserService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [UserDropDownComponent],
      imports: [DropDownsModule],
      // providers: [
      //   { provide: UserService, useClass: MockUserService }
      // ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserDropDownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});


