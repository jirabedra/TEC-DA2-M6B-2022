import { Component, OnInit } from '@angular/core';

import { Observable, Subject } from 'rxjs';

import {
   debounceTime, distinctUntilChanged, switchMap
 } from 'rxjs/operators';

import { Coach } from '../coach';
import { CoachService } from '../coach.service';

@Component({
  selector: 'app-coach-search',
  templateUrl: './coach-search.component.html',
  styleUrls: [ './coach-search.component.css' ]
})
export class CoachSearchComponent implements OnInit {
  heroes$!: Observable<Coach[]>;
  private searchTerms = new Subject<string>();

  constructor(private heroService: CoachService) {}

  // Push a search term into the observable stream.
  search(term: string): void {
    this.searchTerms.next(term);
  }

  ngOnInit(): void {
    this.heroes$ = this.searchTerms.pipe(
      // wait 300ms after each keystroke before considering the term
      debounceTime(300),

      // ignore new term if same as previous term
      distinctUntilChanged(),

      // switch to new search observable each time the term changes
      switchMap((term: string) => this.heroService.searchCoaches(term)),
    );
  }
}
