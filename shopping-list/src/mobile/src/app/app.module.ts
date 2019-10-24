import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import { IonicModule, IonicRouteStrategy } from '@ionic/angular';
import { environment } from 'src/environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { API_BASE_URL, ShoppingListClient } from './clients/api';
import { ListContextMenuComponent } from './my-lists/list-context-menu/list-context-menu.component';

@NgModule({
    declarations: [AppComponent, ListContextMenuComponent],
    entryComponents: [ListContextMenuComponent],
    imports: [
        BrowserModule,
        IonicModule.forRoot(),
        AppRoutingModule,
        HttpClientModule
    ],
    providers: [
        StatusBar,
        SplashScreen,
        { provide: RouteReuseStrategy, useClass: IonicRouteStrategy },
        ShoppingListClient,
        { provide: API_BASE_URL, useValue: environment.apiUrl }
    ],
    bootstrap: [AppComponent]
})
export class AppModule {}
