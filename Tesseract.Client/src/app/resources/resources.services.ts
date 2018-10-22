import serviceUrls from './json/serviceUrls.json';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
  
export class ResourcesService {
    serviceUrls: any;
    constructor() {
        this.serviceUrls = serviceUrls;
    }
  }