import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss'
})
export class NavComponent {

  isCollapsed: boolean = true;
  message = 'expanded';

  collapsed(): void {
    this.message = 'collapsed';
  }

  collapses(): void {
    this.message = 'collapses';
  }

  expanded(): void {
    this.message = 'expanded';
  }

  expands(): void {
    this.message = 'expands';
  }


  toggleCollapse() {
    this.isCollapsed = !this.isCollapsed;
  }
}
