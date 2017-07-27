import { Component, OnInit } from '@angular/core';
import { MakeService } from "../app/services/make.service";

@Component({
  selector: 'app-game-form',
  templateUrl: './game-form.component.html',
  styleUrls: ['./game-form.component.css']
})
export class GameFormComponent implements OnInit {
    families: any[]; 
    categories: any[];
    mechanics: any[];
    game: any = {};
  constructor(private makeService: MakeService) { }

  ngOnInit() {
      this.makeService.getFamilies().subscribe(families => this.families = families);
      this.makeService.getMechanics().subscribe(mechanics => this.mechanics = mechanics);
      




  }
  onMakeChange() {
      var selectedFamily = this.families.find(m => m.id == this.game.family)
      this.categories = selectedFamily.categories;
    }

}

