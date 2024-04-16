using System;
using System.Reflection;
using Zavod_IT_TextGame;
using Zavod_IT_TextGame.Commands;
GameController gameController = new GameController();
initGame();
void initGame()
{
    //Init Rooms
    Room Kitchen = new SpecialRoom();
    Room Corridor = new Room("Коридор");
    Room MyRoom = new Room("Комната");
    Room Street = new Room("Улица");
    GameObjectStorage.AddRoom(Kitchen);
    GameObjectStorage.AddRoom(Corridor);
    GameObjectStorage.AddRoom(MyRoom);
    GameObjectStorage.AddRoom(Street);
    //Set AddjustmentEnterMessages
    Kitchen.AddjustmentEnterMessage = "Надо собрать рюкзак и идти в универ";
   
    //Init Items
    Item Keys= new Item("Ключи",$"Вы взяли Ключи.");
    Item Conspects =new Item("Конспекты", "Вы взяли Конспекты");
    Item BackPack = new Item("Рюкзак", "Вы взяли Рюкзак");
    Item Soup = new Item("Суп", "Вы покушали Суп");
    Soup.CanBeEaten= true;  

    GameObjectStorage.AddItem(Keys);
    GameObjectStorage.AddItem(Conspects);
    GameObjectStorage.AddItem(BackPack);
    GameObjectStorage.AddItem(Soup);
    //Commands
    var types = Assembly.GetExecutingAssembly().GetTypes();
    var implementingTypes = types.Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface);
    foreach (var type in implementingTypes)
    {
        ICommand? command = (ICommand?)Activator.CreateInstance(type);
        if (command == null) Console.WriteLine("Ошибка при добавлении действий");
        else GameObjectStorage.AddCommand(command);
    }
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
    Corridor.AddAdjoiningRoom(MyRoom, Kitchen);
    Street.AddAdjoiningRoom();

    //add Items
    MyRoom.AddItem(Keys);
    MyRoom.AddItem(Conspects);
    MyRoom.AddItem(BackPack);
    Kitchen.AddItem(Soup);
    //EnterMessages

    //GameStart
    gameController.startRoom = Kitchen;
    gameController.InitGame();
}

