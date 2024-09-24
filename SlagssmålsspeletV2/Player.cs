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




}