using UnityEngine;

public class DragDropManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  private int successCount = 0;
    public int totalToMatch = 3;

    [SerializeField] GameObject endPanel; 
    public void RegisterSuccess()
    {
        successCount++;
        if (successCount >= totalToMatch)
        {
            Debug.Log("All objects matched successfully!");
            endPanel.SetActive(true);

        }
    }
}
