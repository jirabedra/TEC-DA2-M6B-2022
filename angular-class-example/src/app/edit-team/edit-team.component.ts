import { Component, OnInit, Input } from '@angular/core';
import { Team } from '../team';

@Component({
  selector: 'app-edit-team',
  templateUrl: './edit-team.component.html',
  styleUrls: ['./edit-team.component.css'],
})
export class EditTeamComponent implements OnInit {
  @Input() selectedTeam?: Team;

  constructor() {}

  onClose(): void {
    this.selectedTeam = undefined;
  }

  ngOnInit(): void {}
}
