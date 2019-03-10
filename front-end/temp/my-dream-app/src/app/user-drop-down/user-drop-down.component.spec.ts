import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserDropDownComponent } from './user-drop-down.component';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

describe('UserDropDownComponent', () => {
  let component: UserDropDownComponent;
  let fixture: ComponentFixture<UserDropDownComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserDropDownComponent ],
      imports: [
        DropDownsModule
      ]
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
