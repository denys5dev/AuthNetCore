import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../../core/auth.service';
@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {

    loginForm: FormGroup;
    constructor(private _fb: FormBuilder, private _authService: AuthService) {
        this.loginForm = this._fb.group({
            username: [null],
            password: [null]
        });
    }

    ngOnInit() {
    }

    onSubmit(form: FormGroup) {
        this._authService.login(form.value).subscribe(res => {
            localStorage.setItem('token', res.tokenString);
        });
    }
}
