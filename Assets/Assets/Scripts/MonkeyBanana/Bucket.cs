using UnityEngine;

public class Bucket : MonoBehaviour
{
  
    [SerializeField] GameObject[] basketBanana;
    [SerializeField] GameObject[] bananaNumberCount;

    [SerializeField] GameObject endPanel;
    int count=0;


    private void OnTriggerEnter2D(Collider2D other)
    {
       
    if (other.CompareTag("Banana")) //banana tag
    {
        Debug.Log("trigger");
        count++;
        other.gameObject.SetActive(false);
        basketBanana[count - 1].SetActive(true);
        bananaNumberCount[count - 1].SetActive(true);
        if (count >= basketBanana.Length)
        {
            Debug.Log("complete");
            endPanel.SetActive(true);
           
        }
    }
}
}
