import { Directive, ElementRef, inject, Input, OnInit } from "@angular/core";
import { NavigationEnd, Router } from "@angular/router";

@Directive({
    standalone: true,
    selector: '[appActiveLink]'
})
export class ActiveLinkDirective implements OnInit {
    @Input() appActiveLink = "";
    @Input() exactMatch: boolean = true;
    router = inject(Router)
    el = inject(ElementRef)
    

    ngOnInit(){
        if (this.exactMatch ? this.router.url === this.appActiveLink : this.router.url.startsWith(this.appActiveLink)) {
            this.el.nativeElement.classList.add('active');
        } else {
            this.el.nativeElement.classList.remove('active');
        }
        this.router.events.subscribe((event) => {
            if (event instanceof NavigationEnd){
                if (this.exactMatch ? this.router.url === this.appActiveLink : this.router.url.startsWith(this.appActiveLink)) {
                    this.el.nativeElement.classList.add('active');
                } else {
                    this.el.nativeElement.classList.remove('active');
                }
            }
        })
    }
}