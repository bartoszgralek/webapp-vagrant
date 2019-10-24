import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { shareReplay } from 'rxjs/operators';
import { GetListByIdItem, SetAsAlreadyBoughtCommand } from '../clients/api';
import { ShoppingListClient } from './../clients/api';

@Component({
    selector: 'app-shopping-list-details',
    templateUrl: './shopping-list-details.page.html',
    styleUrls: ['shopping-list-details.page.scss']
})
export class ShoppingListDetailsPage implements OnInit {
    constructor(
        private route: ActivatedRoute,
        private shoppingListClient: ShoppingListClient,
        private router: Router
    ) {}

    public defaultHref = '/my-lists';
    public itemsToBuy: GetListByIdItem[];
    public itemsBought: GetListByIdItem[];
    public listName: string;

    private shoppingListId: number;
    public allItems: GetListByIdItem[];

    public ngOnInit() {
        this.route.params.subscribe(params => {
            this.shoppingListId = params.id;
        });
    }

    public ionViewWillEnter() {
        this.shoppingListClient
            .getById(this.shoppingListId)
            .pipe(shareReplay(1))
            .subscribe(response => {
                this.listName = response.shoppingListName;
                this.allItems = response.items;
                this.sortItems();
            });
    }

    public openAddNewProductPage() {
        this.router.navigateByUrl(`add-product-to-list/${this.shoppingListId}`);
    }

    public handleProductStateChange(state: boolean, listItem: GetListByIdItem) {
        listItem.alreadyBought = state;

        const command = {
            shoppingListItemId: listItem.itemId,
            alreadyBought: state
        } as SetAsAlreadyBoughtCommand;

        this.shoppingListClient.setAsAlreadyBought(command).subscribe();

        setTimeout(() => {
            this.sortItems();
        }, 500);
    }

    private sortItems(): void {
        this.allItems = this.allItems.sort((x, y) => {
            return this.compareBoolean(x.alreadyBought, y.alreadyBought) === 0
                ? this.compareString(x.productName, y.productName)
                : this.compareBoolean(x.alreadyBought, y.alreadyBought);
        });
    }

    private compareBoolean(x: boolean, y: boolean): number {
        return x === y ? 0 : x ? 1 : -1;
    }

    private compareString(x: string, y: string): number {
        return ('' + x).localeCompare(y);
    }
}
