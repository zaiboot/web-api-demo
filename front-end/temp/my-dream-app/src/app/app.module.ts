import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { UserDropDownComponent } from './user-drop-down/user-drop-down.component';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProjectListComponent } from './project-list/project-list.component';
import { GridModule } from '@progress/kendo-angular-grid';




@NgModule({
  declarations: [
    AppComponent,
    UserDropDownComponent,
    ProjectListComponent    
  ],
  imports: [
    BrowserModule,
    DropDownsModule,
    BrowserAnimationsModule,
    GridModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
