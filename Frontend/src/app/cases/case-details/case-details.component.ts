import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ActivatedRoute, Router} from '@angular/router';
import {environment} from '../../../environments/environment';
import {Message} from '../../interfaces/message';
import {AssignedCase} from '../../interfaces/assigned-case';
import {NbAuthJWTToken, NbAuthService} from '@nebular/auth';
import * as signalR from '@microsoft/signalr';
import {SendMessageToClientCommand} from '../../interfaces/send-message-to-client-command';
import {NbAccessChecker} from '@nebular/security';
import {Location} from '@angular/common';

@Component({
  selector: 'app-case-details',
  templateUrl: './case-details.component.html',
  styleUrls: ['./case-details.component.css']
})
export class CaseDetailsComponent implements OnInit {
  assignedCase: AssignedCase;
  messages: Message[];
  teamMemberName: string;

  constructor(private http: HttpClient, private route: ActivatedRoute, private authService: NbAuthService,
              public accessChecker: NbAccessChecker, private router: Router, private location: Location) {
  }

  ngOnInit(): void {
    this.authService
      .onTokenChange()
      .subscribe((token: NbAuthJWTToken) => {
        if (token.isValid()) {
          this.teamMemberName = token.getPayload().unique_name;
          const hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(environment.telegramBot + 'webhooks', {accessTokenFactory: () => token.getValue()})
            .withAutomaticReconnect()
            .build();
          hubConnection.on("SendText", (text: string) => {
            this.messages.push({
              type: 'text',
              text: text,
              reply: false,
              sender: this.assignedCase.client.fullName,
              createdAt: new Date()
            });
          });
          hubConnection.on("NotifyDirector", (text: string) => {
            this.messages.push({
              type: 'text',
              text: text,
              reply: true,
              sender: this.teamMemberName,
              createdAt: new Date()
            });
          });
          hubConnection
            .start()
            .then();
        }
      });
    this.route.params.subscribe(params => {
      this.http
        .get<AssignedCase>(environment.webAPI + `cases/${params.id}`)
        .subscribe(response => this.assignedCase = response);
      this.http
        .get<Message[]>(environment.webAPI + `cases/${params.id}/messages`)
        .subscribe(response => {
          this.messages = response;
          this.messages.push();
        });
    });
  }

  sendMessage(event: any) {
    const command: SendMessageToClientCommand = {
      caseId: this.assignedCase.id,
      clientId: this.assignedCase.client.id,
      text: event.message,
      sender: this.teamMemberName,
      createdAt: new Date()
    };
    this.http
      .post(environment.webAPI + `cases/${this.assignedCase.id}/messages`, command)
      .subscribe(() => {
        this.messages.push({
          type: 'text',
          text: event.message,
          reply: true,
          sender: this.teamMemberName,
          createdAt: command.createdAt
        });
      })
  }

  goBack() {
    this.location.back();
  }

  unassign(id: string) {
    this.http
      .post(environment.webAPI + `cases/${id}/unassign`, {})
      .subscribe(() => {
        this.router
          .navigate(['../unassigned'], {relativeTo: this.route})
          .then();
      });
  }

  close(id: string) {
    this.http
      .post(environment.webAPI + `cases/${id}/close`, {})
      .subscribe(() => {
        this.router
          .navigate(['../closed'], {relativeTo: this.route})
          .then();
      });
  }
}
