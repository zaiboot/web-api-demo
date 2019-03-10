import { Component, OnInit } from '@angular/core';


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
