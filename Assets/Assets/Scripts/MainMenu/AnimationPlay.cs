using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Diagnostics;
public class AnimationPlay : MonoBehaviour
{
     [SerializeField] float duration=.3f;
    Vector3 target = new Vector3(1, 1, 0);
Vector3 tryobject = new Vector3(1, 1, 0);
    public void ScaleUpanim()
    {
        transform.DOScale(target, duration);
        
    }

}