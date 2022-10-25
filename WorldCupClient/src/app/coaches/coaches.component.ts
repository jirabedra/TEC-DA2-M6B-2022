import { Component, OnInit } from '@angular/core';

import { Coach } from '../coach';
import { CoachService } from '../coach.service';

@Component({
  selector: 'app-coaches',
  templateUrl: './coaches.component.html',
  styleUrls: ['./coaches.component.css']
})
export class CoachesComponent implements OnInit {
  heroes: Coach[] = [];

  constructor(private heroService: CoachService) { }

  ngOnInit(): void {
    this.getCoaches();
  }

  getCoaches(): void {
    this.heroService.getCoaches()
    .subscribe(heroes => this.heroes = heroes);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.heroService.addCoach({ name } as Coach)
      .subscribe(hero => {
        this.heroes.push(hero);
      });
  }

  delete(hero: Coach): void {
    this.heroes = this.heroes.filter(h => h !== hero);
    this.heroService.deleteCoach(hero.id).subscribe();
  }

}
