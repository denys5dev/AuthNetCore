import { AuthService } from '../../core/auth.service';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})

export class HeaderComponent {
    
    constructor(private _authService: AuthService) {
    }

    logout() {
        localStorage.clear();
    }
}
