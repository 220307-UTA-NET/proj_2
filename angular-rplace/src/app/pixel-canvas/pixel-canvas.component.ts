import { Component, OnInit } from '@angular/core';
import { stringify } from 'querystring';
import { Pixel } from '../pixel';

@Component({
  selector: 'app-pixel-canvas',
  templateUrl: './pixel-canvas.component.html',
  styleUrls: ['./pixel-canvas.component.css']
})
export class PixelCanvasComponent implements OnInit {

  selectedColor?: string = "#eee";
  selectedPixel?: Pixel;
  color?: string;
  
  ChangeColor(color: string): string{
    
    this.color = this.selectedColor;
    return color;
  }
  onTest(): void{
    this.selectedColor = "#ff000f";
  }
  constructor() { }

  ngOnInit(): void {
  }
  

}
