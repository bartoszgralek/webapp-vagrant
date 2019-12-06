import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { ManModel } from './manModel'

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  constructor(private httpClient: HttpClient) { }

  public getSample(): Observable<string> {
    let url = "http:/localhost:8080/api/people";

    return this.httpClient.get(url, {responseType: 'text'})
  }
}
