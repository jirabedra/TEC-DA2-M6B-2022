import { Component, Input, OnInit } from '@angular/core';
import { Team } from '../types/Team';

@Component({
  selector: 'app-button-container',
  templateUrl: './button-container.component.html',
  styleUrls: ['./button-container.component.css'],
})
export class ButtonContainerComponent implements OnInit {
  constructor() {}

  @Input() receivedTeam?: Team;

  onClick(): void {
    if (this.receivedTeam) {
      this.receivedTeam.cant++;
    }
  }

  ngOnInit(): void {}
}
