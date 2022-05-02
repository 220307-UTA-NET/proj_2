import { Component, OnInit, VERSION } from '@angular/core';
import { HttpClient, JsonpClientBackend, HttpHeaders} from '@angular/common/http';
import { SharedService } from '../shared/shared.service';
import { Observable } from 'rxjs';

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
    public Color: string,
    public created_at: string,
    public updated_at: string,
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

  constructor(
    private httpClient: HttpClient, private shared:SharedService
  ) { }

  ngOnInit() : void {
    this.httpClient.get<Guest>(`https://localhost:7161/api/guest/ipaddress/${this.guestIp}`).subscribe(response => {
      this.currentGuest.id = response.id;
      this.currentGuest.ipAddress = response.ipAddress;
      this.currentGuest.lastPlace = response.lastPlace;
      this.currentGuest.created_at = response.created_at;
      this.currentGuest.updated_at = response.updated_at;
    })
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

  createGuest(ip:string)
  {
    console.log(ip);
    this.httpClient.post<any>(`https://localhost:7161/api/guest/ipaddress/${ip}`, (ip), { 'headers': headers }).subscribe(error => {console.error('Guest ip already registered in database')});
    this.httpClient.get<Guest>(`https://localhost:7161/api/guest/ipaddress/${ip}`).subscribe(response => {
      this.currentGuest.id = response.id;
      this.currentGuest.ipAddress = response.ipAddress;
      this.currentGuest.lastPlace = response.lastPlace;
      this.currentGuest.created_at = response.created_at;
      this.currentGuest.updated_at = response.updated_at;
    })
    console.log(this.currentGuest);
  }

  changePixelGuest(Pid:number, Gid:number, hex:string) {
    this.httpClient.put<void>(`https://localhost:7161/api/pixel/${Pid}/${Gid}/${hex}`, Pid)
  }

  loadIp()
  {
    this.httpClient.get('https://jsonip.com').subscribe(
      (value:any) => {
        this.guestIp = value.ip;
      }
    );
    return this.guestIp;
  }
}
