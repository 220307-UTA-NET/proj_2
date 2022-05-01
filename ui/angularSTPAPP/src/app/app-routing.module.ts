import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {PixelComponent} from './pixel/pixel.component'

const routes: Routes = [
{path:'pixel',component:PixelComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
