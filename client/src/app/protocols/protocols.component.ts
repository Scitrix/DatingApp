import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Pagination } from '../_models/pagination';
import { Protocol } from '../_models/protocol';
import { ProtocolService } from '../_services/protocol.service';

@Component({
  selector: 'app-protocols',
  templateUrl: './protocols.component.html',
  styleUrls: ['./protocols.component.css']
})
export class ProtocolsComponent implements OnInit {
  protocol: Partial<Protocol[]>;
  createMode = false;

  constructor(private protocolService: ProtocolService) { }

  ngOnInit(): void {
    this.loadProtocols();
  }

  loadProtocols() {
    this.protocolService.getProtocols().subscribe(protocols => {
      this.protocol = protocols;
    })
  }

  createToggle(){
    this.createMode = !this.createMode;
  }

  deleteProtocol(id: number) {
    this.protocolService.deleteProtocol(id).subscribe(() => {
      this.protocol.splice(this.protocol.findIndex(p => p.id === id), 1);
    })
  }
  
  

  cancelCreateMode(event: boolean) {
    this.createMode = event;
  }

  pageChanged(event: any) {
    this.loadProtocols();
  }
}
