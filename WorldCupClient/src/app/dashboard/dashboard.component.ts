import { Component, OnInit } from '@angular/core';
import { Coach } from '../coach';
import { CoachService } from '../coach.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: [ './dashboard.component.css' ]
})
export class DashboardComponent implements OnInit {
  heroes: Coach[] = [];

  constructor(private heroService: CoachService) { }

  ngOnInit(): void {
    this.getCoaches();
  }

  getCoaches(): void {
    this.heroService.getCoaches()
      .subscribe(heroes => this.heroes = heroes.slice(1, 5));
  }
}
