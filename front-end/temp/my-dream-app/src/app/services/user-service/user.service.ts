import { Injectable } from '@angular/core';
import { User } from './user';
import { Project } from './project';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  getUsers(): User[] {
    let listOfUsers :  User[];
    listOfUsers = [ new User(1, "a1", "b"),
      new User(2, "a2", "b"),
      new User(3, "a3", "b"),
    ];
    return listOfUsers;
  }

  getProjectsPerUser(): Project[] {
    let listOfProjects :  Project[];
    listOfProjects = [ 
      new Project(1, new Date(), new Date(), 10, true),
      new Project(2, new Date(), new Date(), 10, true),
      new Project(3, new Date(), new Date(), 10, true),
      new Project(4, new Date(), new Date(), 10, true),
    ];
    return listOfProjects;
  }

}
