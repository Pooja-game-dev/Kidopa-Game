using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Bananaeffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform[] bananaBasket; // Assign in the inspector
    public GameObject[] targetBanana; // Assign in the inspector
    public float duration = 2f;
    public float WaitForEffect = 1f;

    void Start()
    {
        StartCoroutine(ObjectMove());
    }
    IEnumerator ObjectMove()
    {
        yield return new WaitForSeconds(WaitForEffect);
        for (int i = 0; i < bananaBasket.Length && i < targetBanana.Length; i++)
        {
           bananaBasket[i].GetComponent<SpriteRenderer>().sortingOrder = 5; 
            yield return bananaBasket[i].DOMove(targetBanana[i].transform.position, duration).WaitForCompletion();
          bananaBasket[i].gameObject.SetActive(false);
            targetBanana[i].SetActive(true);
        }
    }
}

