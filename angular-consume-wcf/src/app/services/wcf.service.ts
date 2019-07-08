import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
// import { Observable } from 'rxjs/Observable';
// import 'rxjs/add/operator/map';


@Injectable({
    providedIn: 'root'
})
export class WcfService {
    constructor(private http: HttpClient) {

    };

    getEcho(message: string): Observable<string> {
        return this.http
            .get<string>(`http://localhost:8080/WcfService.svc/echo/${message}`);
    }

    // getSample(Id): Observable<any> {
    //     return this.http.get('sample.svc/sample?Id=' + Id)
    //         .map((response: Response) => <any>response.json());
    // };

}