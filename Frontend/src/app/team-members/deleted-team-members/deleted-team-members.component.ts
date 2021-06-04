import { Component, OnInit } from '@angular/core';
import {TeamMember} from '../../interfaces/team-member';
import {HttpClient} from '@angular/common/http';
import {NbDialogService} from '@nebular/theme';
import {environment} from '../../../environments/environment';
import {DeleteTeamMemberCommand} from '../../interfaces/delete-team-member-command';

@Component({
  selector: 'app-deleted-team-members',
  templateUrl: './deleted-team-members.component.html',
  styleUrls: ['./deleted-team-members.component.css']
})
export class DeletedTeamMembersComponent implements OnInit {
  headers = ['', 'Team', 'DeletedAt', 'Role', 'Actions'];
  rows: TeamMember[];

  constructor(private http: HttpClient, private service: NbDialogService) {
  }

  ngOnInit(): void {
    this.http
      .get<TeamMember[]>(environment.webAPI + 'team-members', {params: {view: 'deleted'}})
      .subscribe(response => this.rows = response);
  }

  restore(id: string) {
    this.http
      .post(environment.webAPI + `team-members/${id}/restore`, {})
      .subscribe(() => {
        const index = this.rows.findIndex(x => x.id === id);
        this.rows.splice(index, 1);
      });
  }

  deletePermanently(id: string) {
    let command: DeleteTeamMemberCommand = {isPermanently: true};
    this.http
      .request('delete', environment.webAPI + `team-members/${id}`, {body: command})
      .subscribe(() => {
        const index = this.rows.findIndex(x => x.id === id);
        this.rows.splice(index, 1);
      });
  }
}
