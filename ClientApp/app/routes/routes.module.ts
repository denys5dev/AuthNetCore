import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { SharedModule } from '../shared/shared.module';
import { PagesModule } from './pages/pages.module';

import { routes } from './routes';
import { AuthService } from '../core/auth.service';

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forRoot(routes),
        PagesModule
    ],
    declarations: [],
    providers: [AuthService],
    exports: [
        RouterModule
    ]
})

export class RoutesModule {
  
}
