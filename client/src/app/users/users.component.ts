import { Component, OnInit } from '@angular/core';
import { Course } from '../_models/course';
import { Group } from '../_models/group';
import { Learner } from '../_models/learner';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  user: User;
  learners: Learner[];
  groups: Group[];
  courses: Course[];
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('user'));
    this.userService.getLearners().subscribe(learners => {
      this.learners = learners;
    })
    this.userService.getGroups().subscribe(groups => {
      this.groups = groups;
    })
    this.userService.getCourses().subscribe(courses => {
      this.courses = courses;
    })
  }

  addUser() {
    
  }

  public gridStyle: any = {
    general: {
        normal: 'grid-cellimg-normal'
    }
}


}
