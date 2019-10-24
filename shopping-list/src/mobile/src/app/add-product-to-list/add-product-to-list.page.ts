import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IonInput } from '@ionic/angular';
import { AddProductByNameCommand, ShoppingListClient } from '../clients/api';
import { ToastrService } from '../services/toastr.service';

@Component({
    selector: 'app-add-product-to-list',
    templateUrl: './add-product-to-list.page.html'
})
export class AddProductToListPage implements OnInit {
    constructor(
        private shoppingListClient: ShoppingListClient,
        private route: ActivatedRoute,
        private toastr: ToastrService
    ) {}

    @ViewChild('addProductInput', { static: false }) input: IonInput;

    public defaultHref = '/my-lists';
    public productName: string;

    private shoppingListId: number;

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.shoppingListId = params.id;
        });
    }

    public addProduct(): any {
        const command = this.buildCommand();
        this.shoppingListClient.addProductByName(command).subscribe(() => {
            this.toastr.success(`Dodano ${this.productName}`, 2000);
            this.input.value = '';
        });
    }

    private buildCommand(): AddProductByNameCommand {
        return {
            shoppingListId: this.shoppingListId,
            productName: this.productName
        } as AddProductByNameCommand;
    }
}
