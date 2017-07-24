import { Component, OnInit } from '@angular/core';
import { MakeService } from "../app/services/make.service";

@Component({
  selector: 'app-game-form',
  templateUrl: './game-form.component.html',
  styleUrls: ['./game-form.component.css']
})
export class GameFormComponent implements OnInit {
    families; 
  constructor(private makeService: MakeService) { }

  ngOnInit() {
      this.makeService.getFamililies().subscribe(families => this.families = families);

      console.log("")
  }

}
