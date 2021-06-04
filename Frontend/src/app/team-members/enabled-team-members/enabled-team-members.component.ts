import {Component, OnInit} from '@angular/core';
import {DeleteTeamMemberCommand} from '../../interfaces/delete-team-member-command';
import {HttpClient} from '@angular/common/http';
import {NbDialogService} from '@nebular/theme';
import {environment} from '../../../environments/environment';
import {TeamMember} from '../../interfaces/team-member';

@Component({
  selector: 'app-enabled-team-members',
  templateUrl: './enabled-team-members.component.html',
  styleUrls: ['./enabled-team-members.component.css']
})
export class EnabledTeamMembersComponent implements OnInit {
  headers = ['', 'Team', 'Added', 'Role', 'Actions'];
  rows: TeamMember[];

  constructor(private http: HttpClient, private service: NbDialogService) {
  }

  ngOnInit(): void {
    this.http
      .get<TeamMember[]>(environment.webAPI + 'team-members', {params: {view: 'enabled'}})
      .subscribe(response => this.rows = response);
  }

  delete(id: string) {
    let command: DeleteTeamMemberCommand = {isPermanently: false};
    this.http
      .request('delete', environment.webAPI + `team-members/${id}`, {body: command})
      .subscribe(() => {
        const index = this.rows.findIndex(x => x.id === id);
        this.rows.splice(index, 1);
      });
  }
}
