import { Component, OnInit } from '@angular/core';

import { ClientService } from '../../services/client.service';
import { Client } from '../../models/client.model';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {

  constructor(private clientService : ClientService) { }

  ngOnInit() {
    this.clientService.getClientList();
  }

  showForEdit(client: Client) {
    this.clientService.selectedClient = Object.assign({}, client);;
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record ?') == true) {
      this.clientService.deleteClient(id)
      .subscribe(x => {
        this.clientService.getClientList();
      })
    }
  }
}
