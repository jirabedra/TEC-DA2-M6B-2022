import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { of } from 'rxjs';

import { CoachSearchComponent } from '../hero-search/coach-search.component';
import { CoachService } from '../coach.service';
import { HEROES } from '../mock-heroes';

import { DashboardComponent } from './dashboard.component';

describe('DashboardComponent', () => {
  let component: DashboardComponent;
  let fixture: ComponentFixture<DashboardComponent>;
  let heroService;
  let getCoachesSpy: jasmine.Spy;

  beforeEach(waitForAsync(() => {
    heroService = jasmine.createSpyObj('CoachService', ['getCoaches']);
    getCoachesSpy = heroService.getCoaches.and.returnValue(of(HEROES));
    TestBed
        .configureTestingModule({
          declarations: [DashboardComponent, CoachSearchComponent],
          imports: [RouterTestingModule.withRoutes([])],
          providers: [{provide: CoachService, useValue: heroService}]
        })
        .compileComponents();

    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should be created', () => {
    expect(component).toBeTruthy();
  });

  it('should display "Top Coaches" as headline', () => {
    expect(fixture.nativeElement.querySelector('h2').textContent).toEqual('Top Coaches');
  });

  it('should call heroService', waitForAsync(() => {
       expect(getCoachesSpy.calls.any()).toBe(true);
     }));

  it('should display 4 links', waitForAsync(() => {
       expect(fixture.nativeElement.querySelectorAll('a').length).toEqual(4);
     }));
});
