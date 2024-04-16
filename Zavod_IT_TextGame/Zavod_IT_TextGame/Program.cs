using System;
using Zavod_IT_TextGame;
using Zavod_IT_TextGame.Commands;
GameController gameController = new GameController();
void main() {
	initGame();
}

void initGame()
{
    //Init Rooms
    Room Kitchen = new Room("Кухня");
    Room Corridor = new Room("Коридор");
    Room MyRoom = new Room("Комната");
    Room Street = new Room("Улица");
    //Set AddjustmentEnterMessages
    Kitchen.AddjustmentEnterMessage = "Надо собрать рюкзак и идти в универ";
   
    //Init Items
    Item Keys= new Item("Ключи");
    Item Conspects =new Item("Конспекты");
    Item BackPack = new Item("Рюкзак");
    Item Soup = new Item("Суп");
    //Events
    BackPack.OnExecute += x => {
        Kitchen.AddjustmentEnterMessage = "Рюкзак собран, похоже надо идти в универ";
        Corridor.AddAdjoiningRoom(Street);
        Street.AddAdjoiningRoom(Corridor);
    };
    Soup.OnExecute += x => { Kitchen.RoomState.State["CanEat"] = false; Kitchen.RemoveItem(Soup); };
    Kitchen.AddAction(new Eat());
    Kitchen.RoomState.State["CanEat"] = true;

    //Add Adjoints for rooms
    Kitchen.AddAdjoiningRoom(Corridor);
    MyRoom.AddAdjoiningRoom(Corridor);
    Corridor.AddAdjoiningRoom(MyRoom,Corridor);
    Street.AddAdjoiningRoom();

    //add Items
    MyRoom.AddItem(Keys);
    MyRoom.AddItem(Conspects);
    MyRoom.AddItem(BackPack);
    Kitchen.AddItem(Soup);

    //GameStart
    gameController.startRoom = Kitchen;
    gameController.InitGame();
}

