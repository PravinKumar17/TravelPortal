import { OverlayModule } from '@angular/cdk/overlay';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Request } from '../models/request';
import { ProfileComponent } from '../profile/profile.component';
import { RequestService } from '../service/request.service';

@Component({
  selector: 'app-viewrequest',
  templateUrl: './viewrequest.component.html',
  styleUrls: ['./viewrequest.component.css']
})
export class ViewrequestComponent implements OnInit {
  request:any;  
  urole:any;
  name:any;

  constructor(private requestservice:RequestService,
    private router:Router,
    private dialogRef:MatDialog) {
      this.urole=localStorage.getItem("role");
      this.name=localStorage.getItem("uname");
      if(this.urole=='manager')
      {
        console.log(this.urole);
        this.requestservice.getAllManager().subscribe(data=>{
          console.log(data);
          this.request=data 
        });
      }
      else if(this.urole=='deptment'){
        console.log(this.urole);
        this.requestservice.getAllHead().subscribe(data=>{
          console.log(data);
           this.request=data 
         });
      }
     }
     
     Ok(e:Request){
       if(this.urole=='manager'){
        e.managerapp="approved";
        this.requestservice.ManagerRequest(e).subscribe(sample=>{
         console.log(sample);
        });
    this.dialogRef.closeAll();

        this.router.navigateByUrl("manager");
       }   
       else if(this.urole=='deptment'){
        e.departmentapp="approved";
        this.requestservice.DepartRequest(e).subscribe(sample=>{
         console.log(sample);
        });
    this.dialogRef.closeAll();
    this.router.navigateByUrl("head");
       }
     }
     Cancel(e:Request){
      if(this.urole=='manager'){
        e.managerapp="cancel";
      this.requestservice.ManagerRequest(e).subscribe(sample=>{
       console.log(sample);
      });
    this.dialogRef.closeAll();
    this.router.navigateByUrl("manager");
      }
      else if(this.urole=='deptment'){
        e.departmentapp="cancel";
        this.requestservice.DepartRequest(e).subscribe(sample=>{
         console.log(sample);
        });
    this.dialogRef.closeAll();
    this.router.navigateByUrl("head");
       }
      
     }
  ngOnInit(): void {
  }
  noclick(){
    this.dialogRef.closeAll();
   }
  
   reset(){
     this.request=new Request();
   }

}
