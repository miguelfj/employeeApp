import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs/Observable'
import { Employee } from '../models/employee'
import { environment } from '../../../environments/environment'

@Injectable()

export class EmployeeService {

  constructor(private httpClient: HttpClient) {

  }

  getEmployees(): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(environment.serverUrl + 'employee');
  }

  getEmployee(id: string): Observable<Employee> {
    const employeeUrl = `${environment.serverUrl}employee/${id}`;

    return this.httpClient.get<Employee>(employeeUrl);
  }

  
}
