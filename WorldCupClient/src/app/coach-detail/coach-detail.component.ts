import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Coach } from '../coach';
import { CoachService } from '../coach.service';

@Component({
  selector: 'app-coach-detail',
  templateUrl: './coach-detail.component.html',
  styleUrls: [ './coach-detail.component.css' ]
})
export class CoachDetailComponent implements OnInit {
  hero: Coach | undefined;

  constructor(
    private route: ActivatedRoute,
    private heroService: CoachService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getCoach();
  }

  getCoach(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    this.heroService.getCoach(id)
      .subscribe(hero => this.hero = hero);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.hero) {
      this.heroService.updateCoach(this.hero)
        .subscribe(() => this.goBack());
    }
  }
}
