import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PremiumCalculatorComponent } from './components/premium-calculator/premium-calculator.component';
import { HttpClientModule } from '@angular/common/http';
import { AppConfigService } from './app-config/app-config.service';
import { AppConfigServiceFactory } from './app-config/app-config.service.factory';

@NgModule({
  declarations: [
    AppComponent,
    PremiumCalculatorComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [AppConfigService,
    { provide: APP_INITIALIZER, useFactory: AppConfigServiceFactory, deps: [AppConfigService], multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
