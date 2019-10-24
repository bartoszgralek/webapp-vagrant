import { Injectable } from '@angular/core';
import { ToastController } from '@ionic/angular';
import { ToastOptions } from '@ionic/core';

@Injectable({
    providedIn: 'root'
})
export class ToastrService {
    constructor(private toastrCtr: ToastController) {}

    public toast: HTMLIonToastElement;

    public success(message: string, duration: number = 1000) {
        const options: ToastOptions = {
            message,
            color: 'success',
            duration
        };

        this.showToast(options).then();
    }

    private async showToast(options: ToastOptions) {
        if (this.toast) {
            this.toast.dismiss();
        }

        this.toast = await this.toastrCtr.create(options);
        this.toast.present();
    }
}
