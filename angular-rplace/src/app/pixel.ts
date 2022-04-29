import { Time } from "@angular/common";

export interface Pixel {
    
    id:number;
    Color: string;
    UpdatedAt: Time;
    UpdatedBy: string;

  }
  const getPixelColor = (pixel : Pixel): string => {
      return pixel.Color;
  }