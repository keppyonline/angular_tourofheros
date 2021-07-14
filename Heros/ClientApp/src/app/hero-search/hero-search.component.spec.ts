/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { HeroSearchComponent } from './hero-search.component';

let component: HeroSearchComponent;
let fixture: ComponentFixture<HeroSearchComponent>;

describe('hero-search component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ HeroSearchComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(HeroSearchComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});