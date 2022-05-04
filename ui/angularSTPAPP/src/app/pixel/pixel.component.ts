import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared/shared.service';

export class Pixel {
  constructor(
    public id: number,
    public Color: any,
    public created_at: any,
    public updated_at: any,
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
  public Selection: Pixel = new Pixel(0, 0, 0, 0, 0);

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
    this.httpClient.put<void>(`https://localhost:7161/api/pixel/${Pid}/${Uid}/${hex}`, Pid).subscribe();
    setTimeout(window.location.reload, 1000);
    location.reload();
  }

  PixelSelection(selectedElement:any)
  {
    this.Selection = selectedElement;
    this.shared.setSelection(this.Selection);
    console.log(this.Selection);
  }


  ngOnInit(): void {
    this.getPixels();
    this.shared.setSelection(this.Selection);
  }


  

}
