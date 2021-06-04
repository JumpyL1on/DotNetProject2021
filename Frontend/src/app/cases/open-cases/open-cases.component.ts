import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {TeamMember} from '../../interfaces/team-member';
import {Case} from '../../interfaces/case';
import {NbDialogService} from '@nebular/theme';
import {environment} from '../../../environments/environment';
import {DialogConfirmComponent} from '../../dialog-confirm/dialog-confirm.component';
import {AssignCaseCommand} from '../../interfaces/assign-case-command';

@Component({
  selector: 'app-open-cases',
  templateUrl: './open-cases.component.html',
  styleUrls: ['./open-cases.component.css']
})
export class OpenCasesComponent implements OnInit {
  headers = ['Status', 'Assignee', 'Updated', 'Actions'];
  rows: Case[];

  constructor(private http: HttpClient, private service: NbDialogService) {
  }

  ngOnInit(): void {
    this.http
      .get<Case[]>(environment.webAPI + 'cases', {params: {view: 'open'}})
      .subscribe(response => this.rows = response);
  }

  unassign(id: string) {
    this.http
      .post(environment.webAPI + `cases/${id}/unassign`, {})
      .subscribe(() => {
        const index = this.rows.findIndex(x => x.id === id);
        this.rows.splice(index, 1);
      });
  }
}
