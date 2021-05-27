import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AssignedCase} from '../../interfaces/assigned-case';
import {environment} from '../../../environments/environment';

@Component({
  selector: 'app-assigned-cases',
  templateUrl: './assigned-cases.component.html',
  styleUrls: ['./assigned-cases.component.css']
})
export class AssignedCasesComponent implements OnInit {
  cases: AssignedCase[];

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.http
      .get<AssignedCase[]>(environment.api + 'cases', {params: {view: 'assigned-to-me'}})
      .subscribe(response => {
        this.cases = response;
      })
  }
}
