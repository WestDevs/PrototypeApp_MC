import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Course } from '../_models/course';
import { Group } from '../_models/group';
import { Learner } from '../_models/learner';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = 'https://localhost:6001/api/';
  constructor(private http: HttpClient) { }

  getLearners() {
    return this.http.get(this.baseUrl + 'learner').pipe(
      map((learner: Learner[]) => {
        if (learner) {
          console.log(learner);
          return learner;
          }
        }
      )
    ) 
  }

  getGroups() {
    return this.http.get(this.baseUrl + 'group').pipe(
      map((groups: Group[]) => {
        if (groups) {
          console.log(groups);
          return groups;
          }
        }
      )
    ) 
  }

  getCourses() {
    return this.http.get(this.baseUrl + 'course').pipe(
      map((courses: Course[]) => {
        if (courses) {
          console.log(courses);
          return courses;
        }
      })
    )
  }

}
