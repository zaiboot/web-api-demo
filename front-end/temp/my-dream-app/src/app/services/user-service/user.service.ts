import { Injectable } from '@angular/core';
import { User } from './user';
import { Project } from './project';
import { Observable } from 'rxjs';
import { of } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  getUsers(): Observable<User[]> {
    let listOfUsers :  User[];
    listOfUsers = [ new User(1, "a1", "b"),
      new User(2, "a2", "b"),
      new User(3, "a3", "b"),
    ];
    return of(listOfUsers);
  }

  getProjectsPerUser(userId: number): Observable<Project[]> {
    let listOfProjects :  Project[];
    listOfProjects = [ 
      new Project(1, new Date(2010,12, 20), new Date(2011,12, 20), 10, true),
      new Project(2, new Date(2011,12, 20), new Date(2012,12, 20), 10, false),
      new Project(3, new Date(2012,12, 20), new Date(2013,12, 20), 10, false),
      new Project(4, new Date(2013,12, 20), new Date(2014,12, 20), 10, true),
      new Project(5, new Date(2015,12, 20), new Date(2014,12, 20), 10, true),
      new Project(6, new Date(2015,12, 20), new Date(2015,12, 20), 10, true),
    ];
    return of(listOfProjects);
  }

}
