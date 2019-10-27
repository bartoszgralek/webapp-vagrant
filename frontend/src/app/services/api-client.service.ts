import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { SampleModel } from './sample.model'

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  constructor(private httpClient: HttpClient) { }

  public getSample(): Observable<string> {
    let url = environment.apiUrl + "/people/1";

    return this.httpClient.get("http://localhost:8080/people", {responseType: 'text'});

    // console.log("Message: " + hello);
    //
    // return this.httpClient.get<SampleModel>(url)
    //   .pipe(
    //     map(response => response.name)
    //   );
  }
}
