import {Component, OnInit} from '@angular/core';
import {Case} from '../../interfaces/case';
import {HttpClient} from '@angular/common/http';
import {NbDialogService} from '@nebular/theme';
import {environment} from '../../../environments/environment';

@Component({
  selector: 'app-closed-cases',
  templateUrl: './closed-cases.component.html',
  styleUrls: ['./closed-cases.component.css']
})
export class ClosedCasesComponent implements OnInit {
  headers = ['', 'Status', 'Assignee', 'Updated'];
  rows: Case[];

  constructor(private http: HttpClient, private service: NbDialogService) {
  }

  ngOnInit(): void {
    this.http
      .get<Case[]>(environment.webAPI + 'cases', {params: {view: 'closed'}})
      .subscribe(response => this.rows = response);
  }
}
