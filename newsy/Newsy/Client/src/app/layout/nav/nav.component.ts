import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/service/auth.service';
import { Author } from 'src/app/data/schema/Author';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  loggedUser!: Author;

  constructor(private authService: AuthService, private router: Router) { 
    this.authService.currentUser.subscribe(x => this.loggedUser = x);
  }

  ngOnInit(): void {
  }

  onLogIn() {
    this.router.navigate(['/auth/login']);
  }

  onLogOut() {
    this.authService.logout();
  }

}
