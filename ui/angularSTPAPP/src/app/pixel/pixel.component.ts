import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared/shared.service';

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
  public Selection: Pixel = new Pixel(0, "none", "none", "none", "none");

  constructor(
    private httpClient: HttpClient, private shared:SharedService
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

// move to user component when ready
  changePixelUser(Pid:number, Uid:number, hex:string) {
    this.httpClient.put<void>(`https://localhost:7161/api/pixel/${Pid}/${Uid}/${hex}`, Pid)
  }

  PixelSelection(selectedElement:any)
  {
    this.Selection = selectedElement;
    this.shared.setSelection(this.Selection);
    console.log(this.Selection);
    /*
    const pixelElements = document.querySelectorAll(".pixel");

    pixelElements.forEach(item => {
      item.setAttribute("class", "pixel");
    })
    */
  }


  ngOnInit(): void {
    this.getPixels();
    this.shared.setSelection(this.Selection);
  }


  

}
