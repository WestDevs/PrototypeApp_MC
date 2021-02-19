import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  isCollapsed = true;
  loggedIn = false;
  viewMode: string;
  
  
  constructor(public accountService: AccountService,
              private router: Router) { }

  ngOnInit(): void {
    var arr = JSON.parse(localStorage.getItem('user'));
  }
  setMode(mode: string) {
    this.viewMode = mode;

    // if (this.viewMode == "login")
    //   this.router.navigate(['/login']);
    //this mode should be passed as input on the app-nav
  }
  login() {
    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }
  logout() {
    this.accountService.logout();
    this.router.navigateByUrl("/");
  }


}
