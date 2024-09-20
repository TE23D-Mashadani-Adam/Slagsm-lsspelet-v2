public class Player
{

    public string name;
    public int hp;
    public int money;
    public int randomPunchPower;
    public int bet;
    public bool playerDead;


    public void playerPunched(Player player, Player player2)
    {
        player.hp -= player2.randomPunchPower;
    }
    public void playerBet(Player player, int bet){
        player.money -= bet;
    }
    public void playerIsDead(Player player){
        player.playerDead = true;
    }
    



}