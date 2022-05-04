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

export class User {
  constructor(
    public id: any,
    public username: any,
    public password: any,
    public lastPlace: any,
    public created_at: any,
    public updated_at: any,
  )
  {}
}

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  public PixelSelection: Pixel = new Pixel(0, "none", "none", "none", "none");
  public UserSelection: User = new User(0, "none", "none", "none", "none", "none");
  constructor() { }
  setSelection(data:Pixel){
    this.PixelSelection = data;
  }
  getSelection()
  {
    return this.PixelSelection;
  }
  setUser(data:User)
  {
    this.UserSelection = data;
  }
  getUser()
  {
    return this.UserSelection;
  }
}
