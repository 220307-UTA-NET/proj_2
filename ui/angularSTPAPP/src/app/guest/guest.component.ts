import { Component, OnInit, VERSION } from '@angular/core';
import { HttpClient, JsonpClientBackend, HttpHeaders} from '@angular/common/http';
import { SharedService } from '../shared/shared.service';
import { lastValueFrom, map, Observable } from 'rxjs';

const headers= new HttpHeaders()
  .set('content-type', 'application/json')
  .set('Access-Control-Allow-Origin', '*');

export class Guest {
  constructor(
    public id: number,
    public lastPlace: any,
    public ipAddress: any,
    public created_at: any,
    public updated_at: any,
  ) 
  {}
}

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
  selector: 'app-guest',
  templateUrl: './guest.component.html',
  styleUrls: ['./guest.component.css']
})
export class GuestComponent implements OnInit {
  guestIp : string = '';
  currentGuest : Guest = new Guest(0, "", "", "", "");
  currentPixel : Pixel = new Pixel(0, "", "", "", "")
  stopgap$ : any;

  constructor(
    private httpClient: HttpClient, private shared:SharedService
  ) { }

  async ngOnInit() : Promise<void> {
    this.loadIp();
    setTimeout(() => {this.getGuest(this.guestIp);}, 99);
    setTimeout(() => {console.log(this.currentGuest);}, 6000);
    
  }

  /*
  .subscribe(
    response => {
    console.log(response);
    for (let index = 0; index < response.length; index++) {
      this.pixels.push(new Pixel(response[index].id, response[index].color, response[index].createdat, response[index].updatedat, response[index].updatedby));
    }
  })
*/

  async createGuest(colorinput : string)
  {
    colorinput = colorinput.substring(1);
    this.httpClient.post<any>(`https://localhost:7161/api/guest/ipaddress/${this.currentGuest.ipAddress}`, (this.currentGuest.ipAddress)).subscribe();
    setTimeout(() => {console.log(this.currentGuest);}, 99);
    console.log("Colorinput, guestid, and selectedpixelid parsed: " + colorinput + " " + this.currentGuest.id + " " + this.shared.PixelSelection.id)
    this.changePixelGuest(this.shared.PixelSelection.id, this.currentGuest.id, colorinput)
  }

  changePixelGuest(Pid:number, Gid:number, hex:string) {
    this.httpClient.put<void>(`https://localhost:7161/api/Pixel/guest/${Pid}/${Gid}/${hex}`, 0).subscribe()
  }

  async getGuest(ip:any) : Promise<void>
  {
    this.httpClient.get<Guest>(`https://localhost:7161/api/guest/ipaddress/${ip}`).pipe(map(response => response)).subscribe(response => {
      this.currentGuest = response;
    })
  }

  async loadIp() : Promise<string>
  {
    this.httpClient.get('https://jsonip.com').subscribe(
      (value:any) => {
        this.guestIp = value.ip;
      }
    );
    return this.guestIp;
  }
}
