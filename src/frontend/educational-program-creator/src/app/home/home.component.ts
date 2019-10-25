import { Component, OnInit } from '@angular/core';
import { ApiClientService } from '../services/api-client.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  public jediName = 'unknown name';

  constructor(private apiClient: ApiClientService) { }

  public loadData() {
    this.apiClient.getSample()
      .subscribe(response => {
        this.jediName = response;
      })
  }

}
