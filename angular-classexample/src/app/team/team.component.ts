import { Component, OnInit } from '@angular/core';
import { Team } from '../team';

const Teams: Team[] = [
  { id: 12, name: 'Dr. Nice' },
  { id: 13, name: 'Bombasto' },
  { id: 14, name: 'Celeritas' },
  { id: 15, name: 'Magneta' },
  { id: 16, name: 'RubberMan' },
  { id: 17, name: 'Dynama' },
  { id: 18, name: 'Dr. IQ' },
  { id: 19, name: 'Magma' },
  { id: 20, name: 'Tornado' },
];

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css'],
})
export class TeamComponent implements OnInit {
  teams: Team[] = Teams;
  selectedTeam?: Team;

  constructor() {}

  onSelect(team: Team): void {
    this.selectedTeam = team;
  }

  ngOnInit(): void {}
}
