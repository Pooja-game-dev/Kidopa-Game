using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int bananaCount = 0;
    public void BananaCollected()
    {
        bananaCount++;
        Debug.Log("Bananas collected: " + bananaCount);
       
      
    }
}
