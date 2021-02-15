import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

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

  constructor(
    private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    this.submitLogin.emit(this.model);
  }

  togglePasswordDisplay() {
    this.fieldTextType = !this.fieldTextType;
  }
  cancel(): void {
    this.cancelLogin.emit(false);
  }

}
