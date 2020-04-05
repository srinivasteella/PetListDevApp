import { Component, OnInit } from '@angular/core';
import { AppService } from './app.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'AGLDevTestClient';
  petTypes$: Observable<any>;
  petsByOwnerGender: any;
  errormessage$: Observable<any>;

  constructor(private appService: AppService) {
  }

  ngOnInit(): void {
    this.petTypes$ = this.appService.getTypes();
    this.errormessage$ = this.appService.errorMessage;
  }
  onSelected(type: string): void {
     this.appService.getPetsByName(type).subscribe(
      p => this.petsByOwnerGender = p
    );

     console.log(this.petsByOwnerGender);
  }
}
