import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user-service/user.service';

@Component({
  selector: 'app-user-drop-down',
  templateUrl: './user-drop-down.component.html',
  styleUrls: ['./user-drop-down.component.scss']
})
export class UserDropDownComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  public listItems: Array<string> = [
    'Baseball', 'Basketball', 'Cricket', 'Field Hockey',
    'Football', 'Table Tennis', 'Tennis', 'Volleyball'
  ];
  public value = ['Basketball', 'Cricket'];
}
