import { Injectable } from "@angular/core";
import {HttpClient} from '@angular/common/http';
import { IMedicine } from "../model/medicine";
import { Observable } from "rxjs";
import { HttpHeaders } from "@angular/common/http";
@Injectable()
export class RegisterService{
    private _serverUrl='http://localhost:64677/medicine'
    constructor(private _http: HttpClient){}

    saveMedicine(medicine: IMedicine): Observable<IMedicine>{
        const headers = new HttpHeaders().set('Content-Type', 'application/json');
        return this._http.post<IMedicine>(this._serverUrl,medicine,{headers: headers})
    }
}