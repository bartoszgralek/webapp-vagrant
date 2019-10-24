import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { IonInput, PopoverController } from '@ionic/angular';
import {
    GetAllListsResponseItem,
    RenameListCommand,
    ShoppingListClient
} from 'src/app/clients/api';
import { ListContextMenuComponent } from '../list-context-menu/list-context-menu.component';

@Component({
    selector: 'app-shopping-list',
    templateUrl: './shopping-list.component.html',
    styleUrls: ['shopping-list.component.scss']
})
export class ShoppingListComponent implements OnInit {
    constructor(
        private popoverController: PopoverController,
        private shoppingListClient: ShoppingListClient
    ) {}

    @Input() list: GetAllListsResponseItem;
    @ViewChild('newNameInput', { static: false })
    newNameInput: IonInput;
    public isRenaming = false;
    public listName: string;

    ngOnInit() {
        this.listName = this.list.listName;
    }

    public async openListContextMenu(event: any) {
        const popover = await this.popoverController.create({
            component: ListContextMenuComponent,
            showBackdrop: false,
            event,
            componentProps: {
                renameCallback: () => this.onRename(popover)
            }
        });

        await popover.present();
    }

    public renameList(newName: string): void {
        const command = {
            listId: this.list.listId,
            newName
        } as RenameListCommand;

        this.shoppingListClient.renameList(command).subscribe(() => {
            this.listName = newName;
            this.isRenaming = false;
        });
    }

    private onRename(popover: HTMLIonPopoverElement): void {
        popover.dismiss().then();

        this.isRenaming = true;

        setTimeout(() => {
            this.newNameInput.setFocus();
        }, 300);
    }
}
