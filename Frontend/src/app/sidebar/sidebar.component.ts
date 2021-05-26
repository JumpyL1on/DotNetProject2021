import {Component, OnInit} from '@angular/core';
import {NbMenuItem} from '@nebular/theme';
import {NbAccessChecker} from '@nebular/security';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  constructor(public accessChecker: NbAccessChecker) {
  }

  ngOnInit(): void {
  }
}
