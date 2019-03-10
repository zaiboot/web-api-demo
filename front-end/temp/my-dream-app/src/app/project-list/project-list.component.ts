import { Component, OnInit, OnDestroy } from '@angular/core';
import { Project } from '../services/user-service/project';
import { UserService } from '../services/user-service/user.service';
import { MessageService } from '../services/message-service/message-service.service';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.scss']
})
export class ProjectListComponent implements OnInit, OnDestroy {

  private userId: number = -1;
  public gridData: Project[];
  private subscription: any;

  constructor(private userService: UserService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.subscription = this.messageService.getMessage().subscribe(message => {
      console.log("new message " , message.content);
      this.subscribeProjectList(message.content.userId);
    });
  }

  ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.subscription.unsubscribe();
}
  subscribeProjectList(userId: number): void {
    console.log("new UserId " , userId);
    this.userService.getProjectsPerUser(userId).subscribe((p: Project[]) => {
      this.gridData = p;
    });
  }


  public CalculateTimeToStart(p: Project): string {
    var timeDiff = p.endDate.getTime() - p.startDate.getTime();
    var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
    return diffDays < 0 ? 'Started' : diffDays.toLocaleString();
  }

}
