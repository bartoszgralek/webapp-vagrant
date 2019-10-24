import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-list-context-menu',
    templateUrl: './list-context-menu.component.html'
})
export class ListContextMenuComponent {
    constructor() {}

    @Input() renameCallback: () => void;

    public onRenameButtonClick() {
        this.renameCallback();
    }
}
