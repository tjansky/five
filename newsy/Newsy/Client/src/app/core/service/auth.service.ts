import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { Observable } from 'rxjs/internal/Observable';
import { Author } from 'src/app/data/schema/Author';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private currentUserSubject: BehaviorSubject<Author | any> ;
  public currentUser: Observable<Author>;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<Author>(JSON.parse(localStorage.getItem('loggedUser')!));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): Author {
    return this.currentUserSubject.value;
}

login(email: string, password: string) {
    return this.http.post<any>(`${environment.baseUrl}/Auth/login`, { email, password })
        .pipe(map(user => {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem('loggedUser', JSON.stringify(user));
            this.currentUserSubject.next(user);
            return user;
        }));
}

  register(firstName: string, email: string, password: string, lastName = "placeholder") {
    return this.http.post<any>(`${environment.baseUrl}/Auth/register`, { firstName, lastName, email, password })
      .pipe(map(user => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('loggedUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      }));
  }

logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('loggedUser');
    this.currentUserSubject.next(null);
}
}
