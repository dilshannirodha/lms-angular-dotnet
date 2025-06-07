import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterModule, AsyncPipe],
  templateUrl: './navbar.component.html',
})
export class NavbarComponent {
  isMenuOpen = false;

  constructor(private authService: AuthService) {}

  get user$() {
    return this.authService.user$;
  }

  logout() {
    this.authService.logout();
    this.isMenuOpen = false;
  }
}