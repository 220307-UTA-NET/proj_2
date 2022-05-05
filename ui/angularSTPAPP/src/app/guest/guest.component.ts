import { Component, OnInit, VERSION } from '@angular/core';
import { HttpClient, JsonpClientBackend, HttpHeaders} from '@angular/common/http';
import { SharedService } from '../shared/shared.service';
import { last, lastValueFrom, map, Observable, catchError } from 'rxjs';
import { Form, FormBuilder } from '@angular/forms';

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


@Component({
  selector: 'app-guest',
  templateUrl: './guest.component.html',
  styleUrls: ['./guest.component.css']
})
export class GuestComponent implements OnInit {
  guestIp : string = '';
  currentGuest : Guest = new Guest(0, "", "none", "", "");
  currentPixel : Pixel = new Pixel(0, "", "", "", "")
  lastPlace : number;


  constructor(
    private httpClient: HttpClient, private shared:SharedService, private formBuilder : FormBuilder
  ) { }

  async ngOnInit() : Promise<void> {
    this.loadIp();
    setTimeout(() => {this.getGuest(this.guestIp);}, 99);
    this.setTimer();
  }

  async createGuest(colorinput : string)
  {
    if(this.setTimer())
    {
    colorinput = colorinput.substring(1);
    this.httpClient.post<any>(`https://localhost:7161/api/guest/ipaddress/${this.currentGuest.ipAddress}`, (this.currentGuest.ipAddress)).subscribe();
    setTimeout(() => {console.log(this.currentGuest);}, 99);
    console.log("last place was ");
    console.log("Colorinput, guestid, and selectedpixelid parsed: " + colorinput + " " + this.currentGuest.id + " " + this.shared.PixelSelection.id)
    this.changePixelGuest(this.shared.PixelSelection.id, this.currentGuest.id, colorinput)
    }
    else
    {

    }
  }

  changePixelGuest(Pid:number, Gid:number, hex:string) {
    this.httpClient.put<void>(`https://localhost:7161/api/Pixel/guest/${Pid}/${Gid}/${hex}`, 0).subscribe()
    setTimeout(() => {  
    window.location.reload(); 
  }, 1000);  
  }

  async getGuest(ip:any) : Promise<void>
  {
    this.httpClient.get<Guest>(`https://localhost:7161/api/guest/ipaddress/${ip}`).pipe(map(response => response)).subscribe(response => {
      this.currentGuest = response;
    })
  }

 setTimer(){
   this.lastPlace = Date.parse(this.currentGuest.lastPlace.toString());
   if(Date.now() < this.lastPlace + 5000)
   {
    return false;
   }
   else
   {
    document.getElementById("TimerNumber").textContent = "0:00";
    return true;
   }
 }


intervalTimer : any = setInterval(() => {
if(this.currentGuest.id != 0)
{
  this.lastPlace = Date.parse(this.currentGuest.lastPlace.toString());
  document.getElementById("TimerNumber").textContent = this.millisToMinutesAndSeconds((Date.now() - this.lastPlace));
}
if(document.getElementById("TimerNumber").textContent == "0:00")
  {
    clearInterval(this.intervalTimer);
  }
}, 1000 );

intervalIP : any = setInterval(() => {
  if(this.currentGuest.ipAddress == "none")
  {
    this.loadIp();
  }
  if(parseInt(document.getElementById("TimerNumber").textContent.substring(document.getElementById("TimerNumber").textContent.length-1)) >= 5 || parseInt(document.getElementById("TimerNumber").textContent.substring(document.getElementById("TimerNumber").textContent.length-2)) >= 1 || parseInt(document.getElementById("TimerNumber").textContent.substring(0, document.getElementById("TimerNumber").textContent.indexOf(":"))) >= 0)
    {
      clearInterval(this.intervalIP);
      clearInterval(this.intervalTimer);
      document.getElementById("TimerNumber").textContent = "You may change a pixel color";
    }
  }, 1000 );

 millisToMinutesAndSeconds(millis:any) {
  var minutes = Math.floor(millis / 60000);
  var seconds = ((millis % 60000) / 1000).toFixed(0);
  return minutes + ":" + (Number(seconds) < 10 ? '0' : '') + Number(seconds);
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


  onUserRegister(data:any)
  {
    this.httpClient.post(`https://localhost:7161/api/UserAcc/`, data).subscribe();
    document.getElementById('registerformShown').id = "registerformHidden";
    document.getElementById('loginformShown').id = "loginformHidden";
  }
  onClickUserShowRegister()
  {
    document.getElementById('registerformHidden').id = "registerformShown";
    document.getElementById('loginformShown').id = "loginformHidden";
  }
  onUserLogin(data:any)
  {
    this.httpClient.get<User>(`https://localhost:7161/username/${data.Username}/${data.Password}`).subscribe((response) => {
      this.shared.UserSelection = response;
    });
    document.getElementById('loginformShown').id = 'loginformHidden';
    document.getElementById('registerformShown').id = 'registerformHidden';
  }
  onClickUserShownLogin()
  {
    document.getElementById('loginformHidden').id = "loginformShown";
    document.getElementById('registerformShown').id = "registerformHidden";
  }


}
