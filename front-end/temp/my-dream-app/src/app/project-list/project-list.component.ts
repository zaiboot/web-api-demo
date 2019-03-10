import { Component, OnInit } from '@angular/core';
import { Project } from '../services/user-service/project';
import { UserService } from '../services/user-service/user.service';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.scss']
})
export class ProjectListComponent implements OnInit {

  private userId: number = -1;
  public gridData: Project[];

  constructor(private userService: UserService) { }

  ngOnInit() : void {
    this.subscribeProjectList(this.userId);
  }

  subscribeProjectList(userId: number): void {
    this.userService.getProjectsPerUser(userId).subscribe((p: Project[]) => {
      this.gridData = p;
    });
  }
  

  public CalculateTimeToStart(p: Project): string {
    var timeDiff = p.EndDate.getTime() - p.StartDate.getTime();
    var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));    
    return diffDays < 0 ?  'Started':diffDays.toLocaleString();
  }

}
