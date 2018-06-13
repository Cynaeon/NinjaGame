public class ExpSystem {

    public static int level = 1;
    public static int exp;
    public static float expToLevelUp = 10;

    public static void GainExp(int amount)
    {
        
        exp += amount;
        if (exp >= expToLevelUp)
        {
            level++;
            GameManager.Instance.player.LevelUp();
            expToLevelUp *= 1.5f;
            exp = 0;
        }
    }
}
