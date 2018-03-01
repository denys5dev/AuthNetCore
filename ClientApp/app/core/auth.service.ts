import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class AuthService {
    constructor(private http: Http) { }
    
    login(body: any) {
        return this.http.post('/api/auth/login', body).map(res => res.json());
    }
}