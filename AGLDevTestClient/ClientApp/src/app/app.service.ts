import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { throwError, Observable, BehaviorSubject, Subject } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AppService {
    private getPetTypes = 'api/Pet/Types';
    private getListofPetsByOwnerGender = 'api/Pet';
    private alertMessage$ = new Subject<string>();
    host: string;
    constructor(private http: HttpClient) {
        this.host = environment.AGLDevTestAPI;
    }
    get errorMessage() {
      return this.alertMessage$;
    }
    getTypes(): Observable<any> {
        const url = `${this.host}/${this.getPetTypes}`;
        const headers = new HttpHeaders()
        .append('Content-Type' , 'application/json');
        return this.http.get<any>(url, {headers}).
        pipe(catchError(error => {
          this.alertMessage$.next(error.message);
          return throwError(error.message);
        } ));
      }

    getPetsByName(pettype: string): Observable<any> {
        const url = `${this.host}/${this.getListofPetsByOwnerGender}/${pettype}`;
        const headers = new HttpHeaders()
        .append('Content-Type' , 'application/json');
        return this.http.get<any>(url, {headers}).pipe(catchError(error => {
          this.alertMessage$.next(error.message);
          return throwError(error.message);
        } ));
      }

  private handleError(err) {
    console.log(err.message);
    this.alertMessage$.next(err.message);
    // // in a real world app, we may send the server to some remote logging infrastructure
    // // instead of just logging it to the console
    // let errorMessage: string;
    // if (err.headers instanceof HttpHeaders) {
    //   console.log(err.headers);
    //   // A client-side or network error occurred. Handle it accordingly.
    //   errorMessage = `An error occurred: ${err.headers.message}`;
    // } else {
    //   // The backend returned an unsuccessful response code.
    //   // The response body may contain clues as to what went wrong,
    //   errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    // }
    return throwError(err.message);
  }
}
