using System.Diagnostics.Contracts;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

Player player = new();
Random random = new();

bool roundCountFinished;




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



    bool roundCountIsInt = false;
    int roundCount = 0;

    bool isInteger = false;

    while (player.money > 0)
    {
        roundCountIsInt = false;
        roundCountFinished = false;
        Console.WriteLine("\n" + "Välj mellan 5 och 10 runder att köra, ifall antal rundor har gått ut så vinner den som har" +
    " mest hp");
        //Användaren måste välja ett siffra mellan 5 och 10
        while (!roundCountIsInt)
        {
            string roundCountInput = Console.ReadLine();
            roundCountIsInt = int.TryParse(roundCountInput, out roundCount);
            if (!roundCountIsInt || roundCount < 5 || roundCount > 10)
            {
                roundCountIsInt = false;
                Console.WriteLine("Skriv ett giltigt nummer mellan 5 och 10");
            }
        }


        isInteger = false;
        player.hp = 100;
        enemyPlayer.hp = 100;

        Console.WriteLine($"{player.name} pengar: {player.money}");



        // Prompt player to enter a valid bet
        while (!isInteger)
        {
            Console.WriteLine("Skriv ditt bet (måste vara ett giltigt nummer):");
            string betString = Console.ReadLine();
            isInteger = int.TryParse(betString, out player.bet);

            if (!isInteger)
            {
                Console.WriteLine("Skriv ett giltigt nummer.");
            }
            else if (player.bet <= 0)
            {
                Console.WriteLine("Ditt bet måste vara mer än noll.");
                isInteger = false; // Gör så att loopen körs om
            }
            else if (player.bet > player.money)
            {
                Console.WriteLine($"Din bet kan inte vara högre summa än dina pengar ({player.money}).");
                isInteger = false; // Gör så att loopen körs om
            }
        }


        //Game scene
        while (true)
        {
            for (int i = 1; i <= roundCount; i++)
            {
                player.playerHit = false;
                enemyPlayer.playerHit = false;

                //Slagsmålet startar
                player.randomPunchPowerWeak = random.Next(10, 30);
                player.randomPunchPowerHard = random.Next(40, 80);

                Console.WriteLine($"Runda {i}" + "\n");

                //Spelaren väljer hur stark slag den ska slå med
                Console.WriteLine($"Vill du använda starkare slag (1), eller svagare (2)? Ifall du inte väljer rätt kommer" +
                 "ditt svara antas som svagare slag");
                int[] hitArray = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

                player.choosePunshPower(random, player, hitArray);


                //Spelaren slår motståndaren, koden drar bort hp ifall spelaren träffade
                player.playerPunshScene(enemyPlayer);

                if (enemyPlayer.hp <= 0)
                {
                    Console.WriteLine($"{enemyPlayer.name} är död. {player.name} vann!");
                    player.money += player.bet;
                    Console.WriteLine($"{player.name} har vunnit bet, och har {player.money} i pengar");
                    break;
                }

                //Enemy player punching
                enemyPlayer.botPlayerPunshScene(random, player, hitArray);

                if (player.hp <= 0)
                {
                    Console.WriteLine($"{player.name} är död. {enemyPlayer.name} vann!");
                    player.money -= player.bet;
                    Console.WriteLine($"{player.name} har förlorat sin bet!");
                    player.gameOver = true;
                    break;
                }
                if (i >= roundCount)
                {
                    roundCountFinished = true;
                }
            }
            //Ifall enemy hade mer hp än player
            if (player.hp < enemyPlayer.hp && roundCountFinished)
            {
                Console.WriteLine("Antal rundor är slut");
                Console.WriteLine($"{enemyPlayer.name} har vunnit!");
                player.money -= player.bet;
                Console.WriteLine($"{player.name} har förlorat sin bet!");
            }
            else if (enemyPlayer.hp < player.hp && roundCountFinished) //Ifall player hade mer hp än enemy
            {
                Console.WriteLine("Antal rundor är slut");
                Console.WriteLine($"{player.name} har vunnit!");
                player.money += player.bet;
                Console.WriteLine($"{player.name} har {player.money} kvar och har vunniy sin bet!");

            }
            //Vi går ut från loopen
            break;
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

