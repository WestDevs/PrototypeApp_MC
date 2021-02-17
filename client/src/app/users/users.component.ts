import { Component, OnInit } from '@angular/core';
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
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('user'));
    this.userService.getLearners().subscribe(learners => {
      this.learners = learners;
    }

    )
  }

}
