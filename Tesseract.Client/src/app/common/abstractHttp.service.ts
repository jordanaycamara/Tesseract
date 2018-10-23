import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class AbstractHttpService {
    private baseUrl: string = "https://localhost:44322/api/v1/";

    constructor(private httpClient: HttpClient) {
    }

    get(url: string) {
        return this.httpClient.get(this.getFullPath(url)).toPromise();
    }

    post(url: string, payload: any) {
        return this.httpClient.post(this.getFullPath(url), payload).toPromise();
    }

    delete(url: string, id: string) {
        var url = this.getFullPath(url) + "/" + id;
        return this.httpClient.delete(url).toPromise();
    }

    private getFullPath(url: string) {
        return this.baseUrl + url;
    }
}