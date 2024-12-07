import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CeoLayoutComponent } from "./shares/ceo-layout/ceo-layout.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'CaseStudy4_UI';
}
