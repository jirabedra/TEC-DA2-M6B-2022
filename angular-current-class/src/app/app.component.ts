import { Component } from '@angular/core';

import { Team } from './types/Team';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'angular-current-class';
  
  team:Team = {
    name: 'The Avengers',
    cant: 0
  };


}
