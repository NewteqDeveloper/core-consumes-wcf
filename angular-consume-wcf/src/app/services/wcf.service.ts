import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { NgxXml2jsonService } from 'ngx-xml2json';

@Injectable({
    providedIn: 'root'
})
export class WcfService {
    constructor(private http: HttpClient, private ngxXml2jsonService: NgxXml2jsonService) {

    };

    getEcho(message: string): Observable<string> {
        return this.http
            .get<string>(`http://localhost:8080/WcfService.svc/echo/${message}`, {
                headers: {
                    'Accept': 'application/json'
                }
            });
    }

    getEchoXml(message: string): Observable<any> {
        return this.http
            .get(`http://localhost:8080/WcfService.svc/echoXml?echoWord=${message}`,
                {
                    // we want to accept xml
                    headers: {
                        'Accept': 'application/xml',
                    },
                    // the HttpClient in angular assumes only JSON responses.
                    // we need to set the responseType to 'text' so that 
                    // this call will actually work, because it returns xml
                    // and the call gives an exception because JSON is expected 
                    responseType: 'text'
                })
            .pipe(map(response => {
                const parser = new DOMParser();
                const xml = parser.parseFromString(response.toString(), 'text/xml');
                const obj = this.ngxXml2jsonService.xmlToJson(xml) as any;
                return obj.string;
            }));
    }
}