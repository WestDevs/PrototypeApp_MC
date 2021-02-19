import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { Organisation } from '../_models/organisation';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit { 
  @Input() orgsFromHomeComponent: any; 
  @Output() cancelLogin = new EventEmitter();
  @Output() submitLogin = new EventEmitter();
  model: any = {};
  fieldTextType: boolean;
  orgs: Organisation[];
  userToken: User;

  constructor(
    private router: Router,
    private accountService: AccountService) { }

  ngOnInit(): void {
    this.getOrganisations();
  }
  
  getOrganisations(){    
    this.accountService.getOrganisions().subscribe(orgs => {
      this.orgs = orgs;
    });
  }

  login() {
    this.submitLogin.emit(this.model);
      // this.accountService.login(this.model).subscribe(response => {
      //   this.userToken = JSON.parse(localStorage.getItem('user'));
      //   console.log(this.userToken);
      //   console.log("loggedin");
      // }, error => {
      //   console.log(error);
      // });
  }

  togglePasswordDisplay() {
    this.fieldTextType = !this.fieldTextType;
  }
  cancel(): void {
    this.cancelLogin.emit(false);
    // this.router.navigate(['/']);
  }

}
