import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'contactdata',
    templateUrl: './contactdata.component.html'
})
export class FetchDataComponent {
    public contacts: Contact[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Contact/GetAll').subscribe(result => {
            this.contacts = result.json() as Contact[];
        }, error => console.error(error));
    }
}

interface Contact {
    name: string;
    address: string;
    phoneNumber: string;
}
