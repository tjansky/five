import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstname: new FormControl(''),
      lastname: new FormControl(''),
      email: new FormControl(''),
      pass: new FormControl('')
    })
  }

  onSubmit(form: FormGroup) {
    console.log(form.value);
    
    this.authService.register(
      form.value.firstname,
      form.value.email,
      form.value.pass,
      form.value.lastname
    ).subscribe(x => console.log("nesto"))
  }

}
