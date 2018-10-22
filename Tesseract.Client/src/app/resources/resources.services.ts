import serviceUrls from './json/serviceUrls.json';
import { Injectable } from '@angular/core';
import * as _ from 'lodash';

@Injectable({
    providedIn: 'root'
})

export class ResourcesService {
    serviceUrls: any;
    _: any;

    constructor() {
        this.serviceUrls = serviceUrls;
        this._ = _;
    }
  }