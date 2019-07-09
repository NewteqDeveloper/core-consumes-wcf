import { Component, OnInit } from '@angular/core';
import { WcfService } from './services/wcf.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'angular-consume-wcf';

  serviceResult: string;
  serviceResultXml: string;

  constructor(private wcfService: WcfService){
  }

  ngOnInit() {
    this.wcfService.getEcho('hello').subscribe(result => {
      this.serviceResult = result;
    });
    this.wcfService.getEchoXml('hello world').subscribe(result => {
      this.serviceResultXml = result;
    });
  }
}
