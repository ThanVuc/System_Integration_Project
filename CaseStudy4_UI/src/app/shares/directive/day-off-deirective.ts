import { Directive, ElementRef, inject, input, Input, OnInit } from "@angular/core";
import { NavigationEnd, Router } from "@angular/router";

@Directive({
    standalone: true,
    selector: '[dayoff]'
})
export class DayOffDirective implements OnInit {
    el = inject(ElementRef)
    router = inject(Router)
    @Input() daysOff: number[] = []
    @Input() thisDay: number | null = 0;
    ngOnInit(): void {
        console.log(this.daysOff);
        this.daysOff.forEach(element => {
            console.log(element);
        });
        if (this.thisDay != null && this.thisDay in this.daysOff){
            this.el.nativeElement.classList.add('day-off');
            console.log(this.daysOff)
        } else {
            this.el.nativeElement.classList.remove('day-off');
        }
        this.router.events.subscribe((event) => {
            if (event instanceof NavigationEnd){
                if (this.thisDay != null && this.thisDay in this.daysOff){
                    this.el.nativeElement.classList.add('day-off');
                } else {
                    this.el.nativeElement.classList.remove('day-off');
                }
            }
        })
    }

}