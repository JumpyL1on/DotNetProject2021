import {Component, OnInit} from '@angular/core';
import {NbDialogService} from '@nebular/theme';
import {DialogConfirmComponent} from '../../dialog-confirm/dialog-confirm.component';
import {HttpClient} from '@angular/common/http';
import {TeamMember} from '../../interfaces/team-member';
import {environment} from '../../../environments/environment';
import {Case} from '../../interfaces/case';
import {AssignCaseCommand} from '../../interfaces/assign-case-command';

@Component({
  selector: 'app-unassigned-cases',
  templateUrl: './unassigned-cases.component.html',
  styleUrls: ['./unassigned-cases.component.css']
})
export class UnassignedCasesComponent implements OnInit {
  teamMembers: TeamMember[];
  headers = ['Status', 'Assignee', 'Updated'];
  rows: Case[];
  value: string;

  constructor(private http: HttpClient, private service: NbDialogService) {
  }

  ngOnInit(): void {
    this.http
      .get<TeamMember[]>(environment.webAPI + 'team-members', {params: {view: 'enabled'}})
      .subscribe(response => this.teamMembers = response);
    this.http
      .get<Case[]>(environment.webAPI + 'cases', {params: {view: 'unassigned'}})
      .subscribe(response => this.rows = response);
  }

  selectedChange(id: string) {
    this.service
      .open(DialogConfirmComponent, {closeOnBackdropClick: false, closeOnEsc: false})
      .onClose
      .subscribe((result: boolean) => {
        if (result === false)
          this.value = null;
        else {
          const command: AssignCaseCommand = {assigneeId: this.value};
          this.http
            .post(environment.webAPI + `cases/${id}/assign`, command)
            .subscribe(() => {
              const index = this.rows.findIndex(x => x.id === id);
              this.rows.splice(index, 1);
            });
        }
      });
  }
}
