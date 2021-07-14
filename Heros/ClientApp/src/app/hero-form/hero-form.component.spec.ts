/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { HeroFormComponent } from './hero-form.component';

let component: HeroFormComponent;
let fixture: ComponentFixture<HeroFormComponent>;

describe('hero-form component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ HeroFormComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(HeroFormComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});