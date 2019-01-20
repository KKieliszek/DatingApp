import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { NgModule } from '@angular/core';

@NgModule({
   imports: [
       BsDropdownModule.forRoot(),
       TabsModule.forRoot()
   ],
   exports: [
    BsDropdownModule,
    TabsModule
   ],
})
export class NgXBootstrapModule { }
