import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { CoreModule } from './core/core.module';
import { LayoutModule } from './layout/layout.module';
import { SharedModule } from './shared/shared.module';
import { RoutesModule } from './routes/routes.module';
@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        CoreModule,
        LayoutModule,
        SharedModule.forRoot(),
        RoutesModule
    ]
})

export class AppModuleShared {
    
}
