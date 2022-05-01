import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

export class Pixel {
  constructor(
    public id: number,
    public Row: number,
    public Col: number,
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
        this.pixels.push(new Pixel(response[index].id, response[index].row, response[index].col, response[index].color, response[index].createdat, response[index].updatedat, response[index].updatedby));
      }
    });

  }

  // todo
  changePixel() {

  }

  ngOnInit(): void {
    this.getPixels();
  }

  

}
