import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { ActiveLinkDirective } from '../directive/active-directive';

@Component({
  selector: 'app-ceo-layout',
  standalone: true,
  imports: [RouterOutlet, RouterLink, ActiveLinkDirective],
  templateUrl: './ceo-layout.component.html',
  styleUrl: './ceo-layout.component.css'
})
export class CeoLayoutComponent {

}
