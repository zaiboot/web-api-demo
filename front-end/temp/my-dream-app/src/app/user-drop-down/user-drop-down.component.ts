import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user-service/user.service';
import { User } from '../services/user-service/user';

@Component({
  selector: 'app-user-drop-down',
  templateUrl: './user-drop-down.component.html',
  styleUrls: ['./user-drop-down.component.scss']
})
export class UserDropDownComponent implements OnInit {


  public Users: User[];

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.Users = this.getUsers();
  }
  getUsers(): User[] {
    return this.userService.getUsers();
  }
}
