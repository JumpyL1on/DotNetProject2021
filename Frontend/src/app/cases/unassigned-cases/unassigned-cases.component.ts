import {Component, OnInit} from '@angular/core';
import {NbDialogService} from '@nebular/theme';
import {DialogConfirmComponent} from '../../dialog-confirm/dialog-confirm.component';
import {HttpClient} from '@angular/common/http';
import {TeamMember} from '../interfaces/team-member';
import {environment} from '../../../environments/environment';
@Component({
  selector: 'app-unassigned-cases',
  templateUrl: './unassigned-cases.component.html',
  styleUrls: ['./unassigned-cases.component.css']
})
export class UnassignedCasesComponent implements OnInit {
  allColumns = ['name', 'size', 'kind', 'items', 'assignee'];
  data: TreeNode<FSEntry>[] = [
    {
      data: {name: 'Unassigned', size: '1.8 MB', items: 5, kind: 'dir'}
    },
    {
      data: {name: 'Reports', kind: 'dir', size: '400 KB', items: 2}
    },
    {
      data: {name: 'Other', kind: 'dir', size: '109 MB', items: 2}
    },
  ];
  value: string;
  teamMembers: TeamMember[];

  constructor(private http: HttpClient, private dialogService: NbDialogService) {
  }

  ngOnInit(): void {
    this.http
      .get<TeamMember[]>(environment.api + 'team-members', {params: {view: 'enabled'}})
      .subscribe(response => {
        this.teamMembers = response;
      })
  }

  selectedChange() {
    this.dialogService.open(DialogConfirmComponent);
  }
}

interface TreeNode<T> {
  data: T;
}

interface FSEntry {
  name: string;
  size: string;
  kind: string;
  items?: number;
}
