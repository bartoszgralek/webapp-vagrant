import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AddListCommand, ShoppingListClient } from './../clients/api';

@Component({
    selector: 'app-create-new-list',
    templateUrl: './create-new-list.page.html'
})
export class CreateNewListPage {
    defaultHref = '/my-lists';
    newListName: string;

    constructor(
        private shoppingListClient: ShoppingListClient,
        private router: Router
    ) {}

    createList() {
        const command = this.buildAddListCommand(this.newListName);
        this.shoppingListClient.addList(command).subscribe(() => {
            this.router.navigateByUrl(this.defaultHref);
        });
    }

    private buildAddListCommand(listName: string): AddListCommand {
        return { listName } as AddListCommand;
    }
}
