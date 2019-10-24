import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PopoverController } from '@ionic/angular';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { GetAllListsResponseItem, ShoppingListClient } from '../clients/api';

@Component({
    selector: 'app-my-lists',
    templateUrl: 'my-lists.page.html',
    styleUrls: ['my-lists.page.scss']
})
export class MyListsPage {
    shoppingLists$: Observable<GetAllListsResponseItem[]>;

    constructor(
        private shoppingListClient: ShoppingListClient,
        private router: Router,
        private popoverController: PopoverController
    ) {}

    openCreateNewListPage(): void {
        this.router.navigateByUrl('/create-new-list');
    }

    ionViewWillEnter() {
        this.shoppingLists$ = this.shoppingListClient
            .getAll()
            .pipe(map(x => x.shoppingLists));
    }
}
