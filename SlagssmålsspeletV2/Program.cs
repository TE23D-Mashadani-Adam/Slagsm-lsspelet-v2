using System.Diagnostics.Contracts;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

Player player = new();
Random random = new();




void enemyNameSelected()
{

}


while (true)
{
    string[] randomEnemyNames = ["Saymmon", "Imad", "Ahmed", "Samir", "Simon", "Kerem", "Abdullah"];
    int randomNum = random.Next(0, randomEnemyNames.Length - 1);
    string enemyName = randomEnemyNames[randomNum];

    Player enemyPlayer = new();
    enemyPlayer.name = enemyName;

    string name = "";
    player.bet = 1;


    while (name == string.Empty)
    {
        Console.WriteLine("Welcome to my game, choose your name:");
        name = Console.ReadLine();
    }

    player.name = name;

    Console.WriteLine("Enemy name are going to be randomly generated, enemy name:");
    Console.WriteLine($"Enemy name: {enemyName}");

    Console.WriteLine($"{player.name}, place a bet");
    bool isInteger = false;

    while (player.money > 0)
    {
        isInteger = false;
        player.hp = 100;
        enemyPlayer.hp = 100;

        Console.WriteLine($"{player.name} money: {player.money}");

        while (true)
        {

            // Prompt player to enter a valid bet
            while (!isInteger)
            {
                Console.WriteLine("Enter your bet (must be a valid number):");
                string betString = Console.ReadLine();
                isInteger = int.TryParse(betString, out player.bet);

                if (!isInteger)
                {
                    Console.WriteLine("Please type a valid number.");
                }
                else if (player.bet <= 0)
                {
                    Console.WriteLine("Your bet must be greater than zero.");
                    isInteger = false; // Gör så att loopen körs om
                }
                else if (player.bet > player.money)
                {
                    Console.WriteLine($"Your bet cannot exceed your available money ({player.money}).");
                    isInteger = false; // Gör så att loopen körs om
                }
            }

            break;
        }

        //Game scene
        while (player.hp > 0 || enemyPlayer.hp > 0)
        {

            player.playerHit = false;
            enemyPlayer.playerHit = false;

            //Slagsmålet startar
            player.randomPunchPowerWeak = random.Next(10, 30);
            player.randomPunchPowerHard = random.Next(40, 80);

            //Spelaren väljer hur stark slag den ska slå med
            Console.WriteLine($"Vill du använda starkare slag (1), eller svagare (2)? Ifall du inte väljer rätt kommer" +
             "ditt svara antas som svagare slag");
            int[] hitArray = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            player.choosePunshPower(random, player, hitArray);


            //Spelaren slår motståndaren, koden drar bort hp ifall spelaren träffade
            player.playerPunshScene(enemyPlayer);

            if (enemyPlayer.hp <= 0)
            {
                Console.WriteLine($"{enemyPlayer.name} is dead");
                player.money += player.bet;
                Console.WriteLine($"{player.name} har vunnit bet, och har {player.money} i pengar");
                break;
            }

            //Enemy player punching
            enemyPlayer.botPlayerPunshScene(random, player, hitArray);

            if (player.hp <= 0)
            {
                Console.WriteLine($"{player.name} is Dead");
                player.money -= player.bet;
                Console.WriteLine($"{player.name} har {player.money} kvar och har förlorat sin bet!");
                player.gameOver = true;
                break;
            }

        }

        if (player.money <= 0)
        {
            Console.WriteLine("Du förlorade alla dina pengar!");
            player.GameOver();
            break;
        }

    }

    if (player.gameOver == true)
    {
        Console.WriteLine("Gameover!");
        break;
    }



}

Console.ReadLine();

