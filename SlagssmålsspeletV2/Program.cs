using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

Player player = new();
Random random = new();




void enemyNameSelected()
{

}


while (true)
{
    string[] randomEnemyNames = ["Adam", "Saymmon", "Imad", "Ahmed", "Samir", "Simon"];
    int randomNum = random.Next(0, 5);
    string enemyName = randomEnemyNames[randomNum];

    Player enemyPlayer = new();
    enemyPlayer.name = enemyName;


    Console.WriteLine("Welcome to my game, choose your name:");
    player.name = Console.ReadLine();

    Console.WriteLine("Enemy name are going to be randomly generated, enemy name:");
    Console.WriteLine($"Enemy name: {enemyName}");

    Console.WriteLine($"{player.name}, please place a bet between 1 and 10 dollars," + "\n" +
    $"Your money: {player.money}");
    bool isInteger = false;

    //Spelaren väljer bet, måste vara ett siffra
    while (!isInteger)
    {
        string betString = Console.ReadLine();
        isInteger = int.TryParse(betString, out player.bet);
        if (!isInteger)
        {
            Console.WriteLine("Pls type a number");
        }
        else
        {
            break;
        }
    }

    while (player.hp > 0 || enemyPlayer.hp > 0)
    {

        player.playerHit = false;
        enemyPlayer.playerHit = false;

        //Slagsmålet startar
        player.randomPunchPowerWeak = random.Next(1, 30);
        player.randomPunchPowerHard = random.Next(40, 80);
        Console.WriteLine($"Vill du använda starkare slag (1), eller svagare (2)? Ifall du inte väljer rätt kommer" +
         "ditt svara antas som svagare slag");
        string punchPowerSort = Console.ReadLine();
        int punchSort = 2;
        int[] hitArray = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        int randomHit = random.Next(0, hitArray.Length);

        switch (punchPowerSort)
        {
            case "1":
                punchSort = 1;
                break;
            case "2":
                punchSort = 2;
                break;
        }

        if (punchSort == 2)
        {
            if (hitArray[randomHit] > 3)

                player.playerHit = true;
        }
        else if (punchSort == 1)
        {
            if (hitArray[randomHit] < 3)
            {
                player.playerHit = true;
            }
        }

        Console.WriteLine("\n" + $"Press enter to punch {enemyName}");
        Console.ReadLine();
        if (player.playerHit)
        {
            enemyPlayer.playerPunched(player, punchSort);
        }
        else
        {
            Console.WriteLine("\n" + "You missed!");
        }
        Console.WriteLine($"{enemyPlayer.name} HP: {enemyPlayer.hp}");

        if (enemyPlayer.hp <= 0)
        {
            Console.WriteLine($"{enemyPlayer.name} is dead");
            break;
        }

        //Enemy player punching

        int randomEnemyPunchPower = random.Next(0, hitArray.Length);

        if (hitArray[randomEnemyPunchPower] > 3)
        {
            enemyPlayer.playerHit = true;
        }

        Console.WriteLine($"{enemyPlayer.name} is punching" + "\n");
        enemyPlayer.randomPunchPowerHard = random.Next(10, 60);
        if (enemyPlayer.playerHit)
        {
            player.playerPunched(enemyPlayer, 1);
        }
        else
        {
            Console.WriteLine("Enemy missed!");
        }
        Console.WriteLine($"{player.name} HP: {player.hp}");

        if(player.hp <= 0){
            Console.WriteLine($"{player.name} is Dead");
        }

    }



}

Console.ReadLine();

