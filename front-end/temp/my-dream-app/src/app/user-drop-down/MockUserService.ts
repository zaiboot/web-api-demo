import { Observable, of } from 'rxjs';
import { User } from '../services/user-service/user';
import { Project } from '../services/user-service/project';
export class MockUserService {
 
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
      new Project(1, new Date(), new Date(), 10, true),
      new Project(2, new Date(), new Date(), 10, false),
      new Project(3, new Date(), new Date(), 10, false),
      new Project(4, new Date(), new Date(), 10, true),
    ];
    return of(listOfProjects);
  }
}
