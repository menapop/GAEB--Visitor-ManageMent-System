import { TokenInterceptor } from './shared/Security/token.interceptor';
import { SecuriedPagesGuard } from './shared/Security/securied-pages.guard';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SearchModule } from './Components/search/search.module'
import { RegisterationModule } from './Components/registeration/registeration.module'
import { RequestModule } from './Components/request/request.module'
import { HeaderComponent } from './Components/LayoutComponents/header/header.component';
import { FooterComponent } from './Components/LayoutComponents/footer/footer.component'
import {AccordionModule} from 'primeng/accordion' 
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {InputTextModule} from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { TooltipModule } from 'primeng/tooltip';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputSwitchModule } from 'primeng/inputswitch';
import { InputNumberModule } from 'primeng/inputnumber';
import { FormsModule } from '@angular/forms';
import { ProgressBarModule } from 'primeng/progressbar';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { LookUpService } from './Services/Lookup.service';
import { MainComponent } from './Components/LayoutComponents/main/main.component'
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MainComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SearchModule,
    RegisterationModule,
    RequestModule,
    FormsModule,
    AccordionModule,
    BrowserAnimationsModule,
    InputTextModule,
    ButtonModule,
    TooltipModule,
    RadioButtonModule,
    InputSwitchModule,
    InputNumberModule,
    ProgressBarModule,
  ],
  providers: [
    LookUpService,
    SecuriedPagesGuard,
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },  
  ],
  bootstrap: [AppComponent],
  
})
export class AppModule { }
