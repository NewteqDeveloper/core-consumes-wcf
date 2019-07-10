import { Component, OnInit } from '@angular/core';
import { CoreService } from './services/core.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'angular-consume-wcf';

  serviceResult: string;
  serviceResultJson: string;

  constructor(private coreService: CoreService){
  }

  ngOnInit() {
    this.coreService.getEcho('hello world').subscribe(result => {
      this.serviceResult = result;
    });
    this.coreService.getEchoJson('hello world JSON').subscribe(result => {
      this.serviceResultJson = result;
    });
  }
}
