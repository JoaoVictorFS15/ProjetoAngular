import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css',
  providers: [{ provide: BsDropdownConfig, useValue: { isAnimated: true, autoClose: true } }]
})

export class NavComponent implements OnInit {

  isCollapsed = true;

  constructor(private router:Router) { }

  ngOnInit(): void {
    
  }

  showMenu(): boolean {
      return this.router.url !== '/user/login' ;
  };
}

