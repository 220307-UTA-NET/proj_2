import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

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

@Component({
  selector: 'app-pixel',
  templateUrl: './pixel.component.html',
  styleUrls: ['./pixel.component.css']
})
export class PixelComponent implements OnInit {
  public pixels: Array<any> = [];
  constructor(
    private httpClient: HttpClient
  ) { }

  getPixels() {
    this.httpClient.get<any>('https://localhost:7161/api/pixel').subscribe(
      response => {
      console.log(response);
      for (let index = 0; index < response.length; index++) {
        this.pixels.push(new Pixel(response[index].id, response[index].color, response[index].createdat, response[index].updatedat, response[index].updatedby));
      }
    });

  }

  // todo
  changePixelUser(Pid:string, Uid:string, hex:string) {
    this.httpClient.put<void>(`https://localhost:7161/api/pixel/${Pid}/${Uid}/${hex}`, Pid)
  }

  decToHex(value:any) {
    if (value > 255) {
      return 'FF';
    } else if (value < 0) {
      return '00';
    } else {
      return value.toString(16).padStart(2, '0').toUpperCase();
    }
  }

  rgbToHex(r:any, g:any, b:any) {
    return '#' + this.decToHex(r) + this.decToHex(g) + this.decToHex(b);
  }

  ngOnInit(): void {
    this.getPixels();
  }


  

}
