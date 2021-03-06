import { Injectable } from '@angular/core';
import { Http } from '@angular/http'
import 'rxjs/add/operator/map';
@Injectable()
export class GameService {

  constructor(private http: Http) { }

  getFamilies() {
      return this.http.get('/api/family')
          .map(res => res.json());

  }

  getMechanics() {
      return this.http.get('/api/mechanic')
          .map(res => res.json());

  }
  getFeatres() {


      return this.http.get('/api/mechanics').map(res => res.json())

  }

}
