import { Component, OnInit } from '@angular/core';
import { HttpClient, JsonpClientBackend, HttpHeaders} from '@angular/common/http';
import { SharedService } from '../shared/shared.service';

const headers= new HttpHeaders()
  .set('content-type', 'application/json')
  .set('Access-Control-Allow-Origin', '*');

export class Guest {
  constructor(
    public id: number,
    public Color: string,
    public created_at: string,
    public updated_at: string,
    public updatedBy: any
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

  guestIp = '';

  constructor(
    private httpClient: HttpClient, private shared:SharedService
  ) { }

  ngOnInit(): void {
    this.loadIp();
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
  }

  changePixelGuest(Pid:number, Gid:number, hex:string) {
    this.httpClient.put<void>(`https://localhost:7161/api/pixel/${Pid}/${Gid}/${hex}`, Pid)
  }

  loadIp() : string
  {
    this.httpClient.get('https://jsonip.com').subscribe(
      (value:any) => {
        this.guestIp = value.ip;
      }
    );
    return this.guestIp;
  }
}
