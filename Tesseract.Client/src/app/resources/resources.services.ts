import serviceUrls from './json/serviceUrls.json';
import constants from './json/constants.json';
import { Injectable } from '@angular/core';
import * as _ from 'lodash';

@Injectable({
    providedIn: 'root'
})

export class ResourcesService {
    serviceUrls: any;
    constants: any;
    _: any;

    constructor() {
        this.serviceUrls = serviceUrls;
        this.constants = constants;
        this._ = _;
    }
  }