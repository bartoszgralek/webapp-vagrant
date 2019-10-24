import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'my-lists',
        pathMatch: 'full'
    },
    {
        path: 'my-lists',
        loadChildren: () =>
            import('./my-lists/my-lists.module').then(m => m.MyListsPageModule)
    },
    {
        path: 'create-new-list',
        loadChildren: () =>
            import('./create-new-list/create-new-list.module').then(
                m => m.CreateNewListPageModule
            )
    },
    {
        path: 'shopping-list-details/:id',
        loadChildren: () =>
            import('./shopping-list-details/shopping-list-details.module').then(
                m => m.ShoppingListDetailsPageModule
            )
    },
    {
        path: 'add-product-to-list/:id',
        loadChildren: () =>
            import('./add-product-to-list/add-product-to-list.module').then(
                m => m.AddProductToListPageModule
            )
    }
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {}
