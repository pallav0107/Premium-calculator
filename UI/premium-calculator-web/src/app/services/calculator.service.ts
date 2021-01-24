import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AppConfigService } from '../app-config/app-config.service';
import { OccupationLookup, CustomerModel } from '../common/models/calculator-model';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  getAllOccupation(): Observable<any> {
    return this.httpClient.get<OccupationLookup>(this.appConfig.apiUrl + "GetOccupations")
  }

  calculatePremium(customer: CustomerModel): Observable<any> {
    return this.httpClient.post(this.appConfig.apiUrl + "CalculatePremium", customer);
  }

  constructor(private httpClient: HttpClient, private appConfig: AppConfigService) { }
}
