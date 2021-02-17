import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Organisation } from '../_models/organisation';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root' 
})
export class AccountService {
  baseUrl = 'https://localhost:6001/api/';
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();
  orgs: any;
  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }
    
  getOrganisions() {
    return this.http.get(this.baseUrl + 'organisations').pipe(
      map((orgs: Organisation[]) => {
        if (orgs) {
          return orgs;
          }
        }
          )
    )     // return this.http.get(this.baseUrl + 'organisations').pipe(
    //   map((orgs: Organisation[]) => {const response = orgs;})
    // )
  }

  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }
  
  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}



// getOrganisations() : Observable<Organisation[]>{
//   this.orgs = this.http.get<Organisation[]>(this.baseUrl + 'organisations');
//   console.log("orgs in the service");
//   console.log(this.orgs);
//   return this.orgs;
// }

