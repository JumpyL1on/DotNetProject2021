import {AfterViewInit, Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ActivatedRoute} from '@angular/router';
import {environment} from '../../../environments/environment';
import {Message} from '../../interfaces/message';
import {AssignedCase} from '../../interfaces/assigned-case';
import {NbAuthJWTToken, NbAuthService} from '@nebular/auth';
import {map} from 'rxjs/operators';
import * as signalR from '@microsoft/signalr';
import {SendMessageToClientCommand} from '../../interfaces/send-message-to-client-command';

@Component({
  selector: 'app-case-details',
  templateUrl: './case-details.component.html',
  styleUrls: ['./case-details.component.css']
})
export class CaseDetailsComponent implements OnInit {
  assignedCase: AssignedCase;
  messages: Message[];
  teamMemberName: string;

  constructor(private http: HttpClient, private route: ActivatedRoute, private authService: NbAuthService) {
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
        .subscribe(response => this.messages = response);
    });
  }

  sendMessage(event: any) {
    const command: SendMessageToClientCommand = {
      caseId: this.assignedCase.id,
      clientId: this.assignedCase.client.id,
      text: event.message,
      createdAt: new Date()
    };
    this.http
      .post(environment.webAPI + `cases/${this.assignedCase.id}/messages`, command)
      .subscribe(() => {
        this.messages.push({
          type: 'text',
          text: event.message,
          reply: true,
          createdAt: command.createdAt
        });
      })
  }
}
