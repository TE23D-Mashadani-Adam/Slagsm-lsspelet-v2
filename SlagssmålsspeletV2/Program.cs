using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

Player player = new();
Random random = new();

    string[] randomEnemyNames = ["Adam", "Saymmon", "Imad", "Ahmed", "Samir", "Simon"];
    int randomNum = random.Next(0, 5);
    string enemyName = randomEnemyNames[randomNum];

void enemyNameSelected()
{
    Console.WriteLine("Enemy name are going to be randomly generated, enemy name:");
    Console.WriteLine($"Enemy name: {enemyName}");
}


while (true)
{

    Console.WriteLine("Welcome to my game, choose your name:");
    player.name = Console.ReadLine();
    enemyNameSelected();

    Console.WriteLine($"{player.name}, please place a bet between 1 and 10 dollars," + "\n" +
    $"Your money: {player.money}");
    bool isInteger = false;

    while (!isInteger)
    {
        string betString = Console.ReadLine();
        isInteger = int.TryParse(betString, out player.bet);
        if (!isInteger)
        {
            Console.WriteLine("Pls type a number");
        }
    }



    Console.WriteLine("\n" + $"Press enter to punch {enemyName}");


Console.WriteLine(player.bet);

}

Console.ReadLine();

