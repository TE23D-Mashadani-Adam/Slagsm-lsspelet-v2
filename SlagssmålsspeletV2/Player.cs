public class Player
{

    public string name;
    public int hp;
    public int money = 100;
    public int randomPunchPower;
    public int bet;
    public bool playerDead;


    public void playerPunched(Player player, Player player2)
    {
        player.hp -= player2.randomPunchPower;
    }
    public void playerBet(){
        money -= bet;
    }
    public void playerIsDead(Player player){
        player.playerDead = true;
    }
    



}