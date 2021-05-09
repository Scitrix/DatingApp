import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ProtocolService } from '../../_services/protocol.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  createForm: FormGroup;
  validationErrors: string[] = [];

  constructor(
    private fb: FormBuilder, private router: Router, private protocolService: ProtocolService
  ) { }

  ngOnInit(): void {
    this.initializeForm();
  }
  
  initializeForm() {
    this.createForm = this.fb.group({
      protocolName: ['', Validators.required]
    })
  }

  createProtocol(){
    this.protocolService.createProtocol(this.createForm.value).subscribe(
      response => {
        window.location.reload();
      },
      error => {
        this.validationErrors = error;
      }
    );
  }
  
  
  cancel() {
    this.cancelCreate.emit(false);
  }

}
