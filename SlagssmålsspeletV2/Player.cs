public class Player
{

    public string name;
    public int hp = 100;
    public int money = 100;
    public int randomPunchPowerHard;
    public int randomPunchPowerWeak;
    public int bet;
    public bool playerDead;
    public bool playerHit;


    public void playerPunched(Player punchingPlayer, int punchPower)
    {
        if(punchPower == 1){
        hp -= punchingPlayer.randomPunchPowerHard;
        }else if(punchPower == 2){
            hp -= punchingPlayer.randomPunchPowerWeak;
        }
    }
   
    public void playerBet(){
        money -= bet;
    }
    public void playerIsDead(Player player){
        player.playerDead = true;
    }
    



}