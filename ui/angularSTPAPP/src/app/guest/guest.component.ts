import { Component, OnInit } from '@angular/core';
import { HttpClient, JsonpClientBackend } from '@angular/common/http';

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

@Component({
  selector: 'app-guest',
  templateUrl: './guest.component.html',
  styleUrls: ['./guest.component.css']
})
export class GuestComponent implements OnInit {

  guestIp = '';

  constructor(
    private httpClient: HttpClient
  ) { }

  ngOnInit(): void {
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
  }

}
