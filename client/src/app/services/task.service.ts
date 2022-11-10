import { Injectable } from '@angular/core';
import { Task } from '../Task';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';



@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private apiUrl = 'https://localhost:5001/api/tasks';

  //   {
  //   "result": null,
  //     "value": [
  //       {
  //         "id": 1,
  //         "text": "Doctors Appointment",
  //         "day": "May 5th at 2: 30pm",
  //         "reminder": true
  //       },
  //       {
  //         "id": 127,
  //         "text": "Meeting at School",
  //         "day": "May 6th at 2pm",
  //         "reminder": false
  //       }
  //     ]
  // }

  constructor(private http: HttpClient) { }

  getTasks(): Observable<Task[]> {
    var tasks = this.http.get(this.apiUrl).pipe(map((data: any) => data.value));
    return tasks;
  }

  deleteTask(task: Task): Observable<Task> {
    const url = `${this.apiUrl}/${task.id}`;
    return this.http.delete<Task>(url);
  }

  updateTaskReminder(task: Task): Observable<Task> {
    const url = `${this.apiUrl}/${task.id}`;
    return this.http.put<Task>(url, task);
  }

  addTask(task: Task): Observable<Task> {
    return this.http.post<Task>(this.apiUrl, task);
  }

}
