import { Injectable } from '@angular/core';

export class Pixel {
  constructor(
    public id: number,
    public Color: string,
    public created_at: string,
    public updated_at: string,
    public updatedBy: any
  ) 
  {}
}

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  public PixelSelection: Pixel = new Pixel(0, "none", "none", "none", "none");
  constructor() { }
  setSelection(data:Pixel){
    this.PixelSelection = data;
  }
  getSelection()
  {
    return this.PixelSelection;
  }
}
