using UnityEngine;
using System.Collections;
using DG.Tweening;
public class AnimationPlay : MonoBehaviour
{
     [SerializeField] float duration=.3f;
    Vector3 target = new Vector3(1, 1, 0);

    public void ScaleUpanim()
    {

        transform.DOScale(target, duration);
        Debug.Log("this is try");
    }

}