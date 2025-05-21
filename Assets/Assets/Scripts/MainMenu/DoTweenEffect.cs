using UnityEngine;
using DG.Tweening;
using System.Collections;
public class DoTweenEffect : MonoBehaviour
{
    public Transform objectToMove; // Assign in the inspector
    public Vector3 targetPosition; // Assign in the inspector
    public float duration = 2f;
    public float WaitForEffect = 1f;

    void Start()
    {
        StartCoroutine(ObjectMove());

    }

    IEnumerator ObjectMove()
    {
        yield return new WaitForSeconds(WaitForEffect);
        objectToMove.DOMove(targetPosition, duration);

    }

}
  
