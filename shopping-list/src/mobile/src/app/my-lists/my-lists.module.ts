import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { IonicModule } from '@ionic/angular';
import { MyListsPage } from './my-lists.page';
import { ShoppingListComponent } from './shopping-list/shopping-list.component';

const routes: Routes = [
    {
        path: '',
        component: MyListsPage
    }
];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        RouterModule.forChild(routes)
    ],
    declarations: [MyListsPage, ShoppingListComponent]
})
export class MyListsPageModule {}
