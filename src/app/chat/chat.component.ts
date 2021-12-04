import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent implements OnInit {
  isCreateRoomModalShow = false;

  constructor() {}

  ngOnInit(): void {}

  rooms: any[] = [
    1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8,
  ];

  createNewRoom() {
    this.isCreateRoomModalShow = !this.isCreateRoomModalShow;
  }
}
