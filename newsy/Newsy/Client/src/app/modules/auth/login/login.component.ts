import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl(''),
      pass: new FormControl('')
    })
  }

  onSubmit(form: FormGroup) {
    console.log(form.value);
    this.authService.login(
      form.value.email,
      form.value.pass,
    ).subscribe(x => {
      this.router.navigate(['/']);
    })
  }

}
