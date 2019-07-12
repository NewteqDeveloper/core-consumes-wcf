import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class CoreService {
    constructor(private http: HttpClient) {

    };

    getEcho(message: string): Observable<string> {
        return this.http
            .get(`http://localhost:5000/wcf/echo?input=${message}`,
            {
                responseType: 'text'
            });
    }

    getEchoJson(message: string): Observable<any> {
        return this.http
            .get(`http://localhost:5000/wcf/echoJson?input=${message}`);
    }

    getEchoJsonParsed(message: string): Observable<string> {
        return this.http
            .get(`http://localhost:5000/wcf/echoJson?input=${message}`)
            .pipe(map((result: any) => {
                return result.value;
            }));
    }
}