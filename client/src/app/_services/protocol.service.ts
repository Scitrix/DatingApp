import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Protocol } from '../_models/protocol';

@Injectable({
  providedIn: 'root'
})
export class ProtocolService {
  baseUrl = environment.apiUrl;
  protocol: Protocol[] = [];

  constructor(private http: HttpClient) { }

  getProtocols() {
    return this.http.get<Partial<Protocol[]>>(this.baseUrl + 'protocol');
  }

  createProtocol(model: any) {
    return this.http.post(this.baseUrl + 'protocol', model);
  }

  deleteProtocol(id: number) {
    return this.http.delete(this.baseUrl + 'protocol/' + id);
  }
}
