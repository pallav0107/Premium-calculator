import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AppConfigService {

    public environmentName: string;
    public apiUrl: string;
    public clientId: string;
    public redirectUri: string;
    public postLogoutRedirectUri: string;
    public silentRedirectUri: string;
    public authority: string;
    public issuer: string;
    public authorizationEndpoint: string;
    public userinfoEndpoint: string;
    public endSessionEndpoint: string;
    public jwksUri: string;
    public signingKeys: string;
    public resource: string;
    public responseType: string;
    public scope: string;

    public releaseVersion: string;
    public buildVersion: string;

    constructor(private http: HttpClient) { }

    loadAppConfig(): Promise<any> {
        return this.http.get('/appconfig.json')
            .toPromise()
            .then(data => {

                for (const key in data) {
                    if (data.hasOwnProperty(key)) {
                        this[key] = data[key];
                    }
                }

                if (this.apiUrl && !(this.apiUrl.endsWith('/'))) {
                    this.apiUrl = this.apiUrl.concat('/');
                }
            });
    }
}