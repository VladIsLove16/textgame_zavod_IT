using System;
using Zavod_IT_TextGame;
void main() {
	initGame();
}

void initGame()
{
    //Add Rooms

    Room Kitchen = new Room("Кухня");
    Room Corridor = new Room("Коридор");
    Room MyRoom = new Room("Комната");
    Room Street = new Room("Улица");
    //Add Adjoints for rooms
    MyRoom.AddAdjoiningRoom(Corridor);

    Corridor.AddAdjoiningRoom(MyRoom);

    //add Items
    MyRoom.AddItem(new Item("Ключи"));
    MyRoom.AddItem(new Item("Конспекты"));
    MyRoom.AddItem(new Item("Рюкзак"));
}

