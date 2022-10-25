import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Coach } from './coach';
import { MessageService } from './message.service';


@Injectable({ providedIn: 'root' })
export class CoachService {

  private heroesUrl = 'http://localhost:13890/api/coaches';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET heroes from the server */
  getCoaches(): Observable<Coach[]> {
    return this.http.get<Coach[]>(this.heroesUrl)
      .pipe(
        tap(_ => this.log('fetched heroes')),
        catchError(this.handleError<Coach[]>('getCoaches', []))
      );
  }

  /** GET hero by id. Return `undefined` when id not found */
  getCoachNo404<Data>(id: number): Observable<Coach> {
    const url = `${this.heroesUrl}/?id=${id}`;
    return this.http.get<Coach[]>(url)
      .pipe(
        map(heroes => heroes[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? 'fetched' : 'did not find';
          this.log(`${outcome} hero id=${id}`);
        }),
        catchError(this.handleError<Coach>(`getCoach id=${id}`))
      );
  }

  /** GET hero by id. Will 404 if id not found */
  getCoach(id: number): Observable<Coach> {
    const url = `${this.heroesUrl}/${id}`;
    return this.http.get<Coach>(url).pipe(
      tap(_ => this.log(`fetched hero id=${id}`)),
      catchError(this.handleError<Coach>(`getCoach id=${id}`))
    );
  }

  /* GET heroes whose name contains search term */
  searchCoaches(term: string): Observable<Coach[]> {
    if (!term.trim()) {
      // if not search term, return empty hero array.
      return of([]);
    }
    return this.http.get<Coach[]>(`${this.heroesUrl}`).pipe(
      tap(x => x.length ?
         this.log(`found heroes matching "${term}"`) :
         this.log(`no heroes matching "${term}"`)),
      catchError(this.handleError<Coach[]>('searchCoaches', []))
    );
  }

  //////// Save methods //////////

  /** POST: add a new hero to the server */
  addCoach(hero: Coach): Observable<Coach> {
    return this.http.post<Coach>(this.heroesUrl, hero, this.httpOptions).pipe(
      tap((newCoach: Coach) => this.log(`added hero w/ id=${newCoach.id}`)),
      catchError(this.handleError<Coach>('addCoach'))
    );
  }

  /** DELETE: delete the hero from the server */
  deleteCoach(id: number): Observable<Coach> {
    const url = `${this.heroesUrl}/${id}`;

    return this.http.delete<Coach>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted hero id=${id}`)),
      catchError(this.handleError<Coach>('deleteCoach'))
    );
  }

  /** PUT: update the hero on the server */
  updateCoach(hero: Coach): Observable<any> {
    return this.http.put(this.heroesUrl, hero, this.httpOptions).pipe(
      tap(_ => this.log(`updated hero id=${hero.id}`)),
      catchError(this.handleError<any>('updateCoach'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a CoachService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`CoachService: ${message}`);
  }
}
