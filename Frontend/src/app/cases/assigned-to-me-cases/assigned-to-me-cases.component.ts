import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AssignedCase} from '../../interfaces/assigned-case';
import {environment} from '../../../environments/environment';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-assigned-to-me-cases',
  templateUrl: './assigned-to-me-cases.component.html',
  styleUrls: ['./assigned-to-me-cases.component.css']
})
export class AssignedToMeCasesComponent implements OnInit {
  cases: AssignedCase[];

  constructor(private http: HttpClient, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.http
      .get<AssignedCase[]>(environment.webAPI + 'cases', {params: {view: 'assigned-to-me'}})
      .subscribe(response => {
        this.cases = response;
      })
  }
}
