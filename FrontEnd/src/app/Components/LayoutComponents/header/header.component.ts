import { Component, OnInit } from '@angular/core';
import { Router, NavigationStart, NavigationEnd } from '@angular/router';
import { filter, map } from 'rxjs/operators';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private router:Router) { }

  mode$ = this.router.events.pipe(
    filter(evt => evt instanceof NavigationStart || evt instanceof NavigationEnd),
    map(evt => evt instanceof NavigationStart ? 'indeterminate' : '')
);
  ngOnInit(): void {
  }

}
