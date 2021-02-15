import { HttpClient } from '@angular/common/http';
import { Component,  OnInit } from '@angular/core';
import { AnonymousSubject } from 'rxjs/internal/Subject';
import { Organisation } from '../_models/organisation';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  logInMode = false;
  users: any;
  orgs: Organisation[];
  serviceOrgs: Organisation[];
  urlString = "https://localhost:6001/"
  loginDetails: any;
  userToken: User;
  loggedIn = false;
  
  constructor(private http: HttpClient,
              private accountService: AccountService) { }

  ngOnInit(): void {
    // this.getUsers();
    this.getOrganisations();
  }

  logInToggle() {
    this.logInMode = !this.logInMode;
  }

  getOrganisations(){    
    this.accountService.getOrganisions().subscribe(orgs => {
      this.orgs = orgs;
    });
  }

  cancelLoginMode(event: boolean) {
    this.logInMode = event;
  }

  submitLogin(loginDetails: any) {
    this.loginDetails = loginDetails;
    this.accountService.login(this.loginDetails).subscribe(response => {
      this.loggedIn = true;
      this.logInMode = false;      
      this.userToken = JSON.parse(localStorage.getItem('user'));
    }, error => {
      console.log(error);
    });

  }

}


//Tested code


// getUsers(){
//   this.http.get(this.urlString + 'api/users').subscribe(response => {
//     console.log(response);
//   }, error => {
//     console.log(error);
//   });
// }
