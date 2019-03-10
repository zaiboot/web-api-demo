import { Injectable } from '@angular/core';
import { User } from './user';
import { Project } from './project';
import { Observable } from 'rxjs';
import { of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    const userUrl = "https://localhost:5001/api/User";
    return this.http.get<User[]>(userUrl);    
  }

  getProjectsPerUser(userId: number): Observable<Project[]> {
    const userUrl = `https://localhost:5001/api/User/${userId}/projects`;
    return this.http.get<Project[]>(userUrl);
  }

}
