import { Directive, ElementRef, Input, OnInit, Self } from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
    selector: '[disabledFormControl]'
})

export class DisableFormControlDirective implements OnInit {

    value: boolean = true;

    @Input()
    set disabledFormControl(condition: boolean) {
        this.value = condition;
        this.setDisabled();
    }

    constructor(@Self() private ngControl: NgControl) { }

    ngOnInit(): void {
        this.setDisabled();
    }

    private setDisabled() {
        if (this.ngControl?.control) {
            if (this.value == true) this.ngControl.control.disable({emitEvent: false});
            else this.ngControl.control.enable({emitEvent: false});

        }
    }
}