import {Component, OnInit} from '@angular/core';
import {NbMenuItem} from '@nebular/theme';
import {NbAccessChecker} from '@nebular/security';

@Component({
  selector: 'app-cases-sidebar',
  templateUrl: './cases-sidebar.component.html',
  styleUrls: ['./cases-sidebar.component.css']
})
export class CasesSidebarComponent implements OnInit {
  constructor(public accessChecker: NbAccessChecker) {
  }

  ngOnInit(): void {
  }
}
