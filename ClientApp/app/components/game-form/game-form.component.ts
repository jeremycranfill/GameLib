import { Component, OnInit } from '@angular/core';
import { GameService } from "../app/services/game.service";


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
  
    constructor(private gameService: GameService) { }

  ngOnInit() {
      this.gameService.getFamilies().subscribe(families => this.families = families);
      this.gameService.getMechanics().subscribe(mechanics => this.mechanics = mechanics);
      
      




  }
  onMakeChange() {
      var selectedFamily = this.families.find(m => m.id == this.game.family)
      this.categories = selectedFamily.categories;
    }

}

