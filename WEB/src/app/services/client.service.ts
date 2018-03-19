import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { Client } from '../models/client.model';


@Injectable()
export class ClientService {

  selectedClient : Client;
  clientList : Client[];
  constructor(private http : Http) { }

  postClient(client : Client){
    var body = JSON.stringify(client);
    alert(body);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post,headers : headerOptions});
    return this.http.post('http://localhost:25304/api/ClientAPI',body,requestOptions).map(x => x.json());
  }

  getClientList(){
    // this.http.get('http://localhost:25304/api/ClientAPI').subscribe(data => {
    //   console.log(data);
    // });

    this.http.get('http://localhost:25304/api/ClientAPI')
    .map((data : Response) =>{
      return data.json() as Client[];
    }).toPromise().then(x => {
      this.clientList = x;
    })
  }

  putClient(id, client) {
    var body = JSON.stringify(client);
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
    return this.http.put('http://localhost:25304/api/ClientAPI/' + id,
      body,
      requestOptions).map(res => res.json());
  }

  deleteClient(id: number) {
    return this.http.delete('http://localhost:25304/api/ClientAPI/' + id).map(res => res.json());
  }
}
