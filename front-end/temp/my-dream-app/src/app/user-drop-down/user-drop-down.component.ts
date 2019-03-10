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
  public defaultItem: User = new User(-1,"-", "");
  constructor(private userService: UserService) { }

  ngOnInit():void {
    this.subscribeToUsers();
  }
  subscribeToUsers():void {
     this.userService.getUsers().subscribe( (u: User[]) =>  {        
        this.Users = u; 
      } );
  }
}
