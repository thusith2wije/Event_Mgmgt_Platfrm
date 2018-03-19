import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms'

import { ClientService } from '../../services/client.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {

  private testVal : string = "testVal2";
  constructor(private clientService : ClientService) { }

  ngOnInit() {
    // this.clientService.selectedClient = {
    //   Id: 1,
    //   Name: 'My Name',
    //   Address: '',
    //   IsActive: false
    // }

    this.resetForm();

  }

  resetForm(form? : NgForm)
  {
    this.clientService.selectedClient = {
      id: null,
      name: '',
      address: '',
      isActive: false
    }
  }


  onSubmit(form : NgForm){
    alert(form.value.id);
    if (form.value.id == null) {
      this.clientService.postClient(form.value)
        .subscribe(data => {
          this.resetForm(form);
          this.clientService.getClientList();
        })
    }
    else {
      this.clientService.putClient(form.value.id, form.value)
      .subscribe(data => {
        this.resetForm(form);
        this.clientService.getClientList();
      });
    }

  }
}
