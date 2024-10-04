public class Player
{

    public string name;
    public int hp = 100;
    public int money = 100;
    public int randomPunchPowerHard;
    public int randomPunchPowerWeak;
    public int randomPunchPower;
    public int bet;
    public bool playerDead;
    public bool playerHit;
    public bool gameOver;


    public void playerPunched(Player punchingPlayer)
    {
        hp -= punchingPlayer.randomPunchPower;
    }


    public void playerBet()
    {
        money -= bet;
    }
    public void playerIsDead(Player player)
    {
        player.playerDead = true;
    }

    public void choosePunshPower(Random random, Player player, int[] hitArray)

    {
        string punchPowerSort = Console.ReadLine();
        int punchSort = 2;
        int randomHit = random.Next(0, hitArray.Length);

        switch (punchPowerSort)
        {
            case "1":
                punchSort = 1;
                break;
            case "2":
                punchSort = 2;
                break;
            default:
                punchSort = 2;
                break;
        }

        if (punchSort == 2)
        {
            player.randomPunchPower = random.Next(10, 30);
            if (hitArray[randomHit] > 3)
                player.playerHit = true;
        }
        else if (punchSort == 1)
        {
            player.randomPunchPower = random.Next(40, 80);
            if (hitArray[randomHit] < 3)
            {
                player.playerHit = true;
            }
        }
    }

    public void playerPunshScene(Player enemyPlayer)
    {
        Console.WriteLine("\n" + $"Press enter to punch {enemyPlayer.name}");
        Console.ReadLine();
        if (playerHit)
        {
            enemyPlayer.playerPunched(this);
            Console.WriteLine("You hitted " + enemyPlayer.name);
        }
        else
        {
            Console.WriteLine("\n" + "You missed!");
        }
        Console.WriteLine($"{enemyPlayer.name} HP: {enemyPlayer.hp}");
    }

    public void botPlayerPunshScene(Random random, Player player, int[] hitArray)

    {
        int randomEnemyPunchPower = random.Next(0, hitArray.Length);

        if (hitArray[randomEnemyPunchPower] > 4)
        {
            playerHit = true;
        }

        Console.WriteLine($"{name} is punching" + "\n");
        randomPunchPower = random.Next(10, 60);
        if (playerHit)
        {
            player.playerPunched(this);
            Console.WriteLine("Enemy hitted you!");
        }
        else
        {
            Console.WriteLine("Enemy missed!");
        }
        Console.WriteLine($"{player.name} HP: {player.hp}");
    }

    public void GameOver()
    {
        Console.WriteLine("Gameover");
    }


}