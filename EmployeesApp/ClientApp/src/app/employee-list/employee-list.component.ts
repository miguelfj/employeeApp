import {Component, OnInit} from '@angular/core'
import { EmployeeService } from '../shared/services/employee.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Employee } from '../shared/models/employee';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html'
})

export class EmployeeListComponent implements OnInit {

  public employees: Employee[];
  public searchForm: FormGroup
  constructor(private service: EmployeeService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.getAllEmployees();
    this.searchForm = this.fb.group({
      employeeId: ['']
    })
  }

  searchEmployee() {
    const employeeId = this.searchForm.value.employeeId;

    if (employeeId != '') {
      this.service.getEmployee(employeeId).pipe(catchError((err) => {
        if (err.status === 404) {
          alert('Employee not found!');
        }
        return Observable.throw('Not found');
      })).subscribe((employee: Employee) => {
        this.employees = [employee];
      })
    }
    else {
      this.getAllEmployees();
    }
  }

  getAllEmployees() {
    this.service.getEmployees().subscribe(employees => this.employees = employees);
  }

}
