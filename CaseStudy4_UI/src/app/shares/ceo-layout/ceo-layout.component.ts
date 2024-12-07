import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-ceo-layout',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './ceo-layout.component.html',
  styleUrl: './ceo-layout.component.css'
})
export class CeoLayoutComponent {

}