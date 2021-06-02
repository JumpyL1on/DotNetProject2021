import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-open-cases',
  templateUrl: './open-cases.component.html',
  styleUrls: ['./open-cases.component.css']
})
export class OpenCasesComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }
}
