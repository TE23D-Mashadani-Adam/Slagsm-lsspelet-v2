using System.Net.Sockets;

Player player = new();
Random random = new();

void choosePlayerNames(){
     string[] randomEnemyNames = ["Adam", "Saymmon", "Imad", "Ahmed", "Samir", "Simon"];
    Console.WriteLine("Enemy name are going to be randomly generated, enemy name:");
    int randomNum = random.Next(0, 5);
    string enemyName = randomEnemyNames[randomNum];
    Console.WriteLine($"Enemy name: {enemyName}");
}


while (true)
{

    Console.WriteLine("Welcome to my game, choose your name:");
    player.name = Console.ReadLine();
    choosePlayerNames();

    Console.WriteLine($"{player.name}, please place a bet between 1 and 10 dollars," + "\n" +
    $"Your money: {player.money}");
    string betString = Console.ReadLine();
    bool isInteger = int.TryParse(betString, out player.bet);

    try{
        player.bet = int.Parse(betString);
    }catch(FormatException){
        Console.WriteLine("pls type in a number");
    }
    }

    Console.WriteLine(player.bet);

    Console.ReadLine();

