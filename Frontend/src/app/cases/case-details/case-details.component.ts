import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-case-details',
  templateUrl: './case-details.component.html',
  styleUrls: ['./case-details.component.css']
})
export class CaseDetailsComponent implements OnInit {
  messages: any[] = [];

  constructor() {
  }

  ngOnInit(): void {
  }

  sendMessage(event: any, userName: string, avatar: string, reply: boolean) {
    this.messages.push({
      text: event.message,
      date: new Date(),
      reply: reply,
      type: 'text',
      user: {
        name: userName,
        avatar: avatar,
      },
    });
  }
}
