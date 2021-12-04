import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatComponent } from './chat/chat.component';
import { FriendComponent } from './friend/friend.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { RoomComponent } from './room/room.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'chat',
    component: ChatComponent,
  },
  {
    path: 'friend',
    component: FriendComponent,
  },
  {
    path: 'profile',
    component: ProfileComponent,
  },
  {
    path: 'room',
    component: RoomComponent,
  },
  {
    path: '**',
    redirectTo: 'chat',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
