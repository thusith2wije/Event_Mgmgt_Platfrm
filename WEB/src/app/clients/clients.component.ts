import { Component, OnInit } from '@angular/core';
import { ClientService } from '../services/client.service'

import { fail } from 'assert';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css'],
  providers: [ClientService]
})
export class ClientsComponent implements OnInit {

  constructor(private clientService : ClientService) { }

  ngOnInit() {
  }

}
