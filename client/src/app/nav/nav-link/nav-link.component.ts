import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-link',
  templateUrl: './nav-link.component.html',
  styleUrls: ['./nav-link.component.css']
})
export class NavLinkComponent implements OnInit {
  isActive = true;
  @Input() viewMode: string; 
  constructor() { }

  ngOnInit(): void {
  }

}
