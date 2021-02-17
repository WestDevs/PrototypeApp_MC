import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
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

}
