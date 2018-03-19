import { Routes } from '@angular/router'
import { ClientsComponent } from './clients/clients.component';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { AuthGuard } from './auth/auth.guard';
import { SignUpComponent } from './user/sign-up/sign-up.component';

export const appRoutes : Routes = [
    { path : 'clients', component: ClientsComponent, canActivate: [AuthGuard]},
    { 
        path : 'signup', component : UserComponent,
        children : [{ path : '', component : SignUpComponent }]
    },        
    { 
        path : 'login', component : UserComponent,
        children : [{ path : '', component : SignInComponent }]
    },
    { path : '', redirectTo : '/login', pathMatch : 'full' }
   
]