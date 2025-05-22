using UnityEngine;
public class MenuUI : MonoBehaviour
{
 public void LoadLevel(string levelName)
    {
        GameManager.Instance.LoadLevel(levelName);
    }
}
