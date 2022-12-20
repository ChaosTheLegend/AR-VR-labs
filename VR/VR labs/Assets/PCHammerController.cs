using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class PCHammerController : MonoBehaviour
{
    [SerializeField] private Transform hammer;
    [SerializeField] private float rotationTime;
    
    
    [Button]
    public void DoRotation()
    {
        //rotate the hammer around the rotation point and then back to the original position
        hammer.DORotate(new Vector3(-90, 0, 0), rotationTime/2).SetEase(Ease.Linear).OnComplete(() =>
        {
            hammer.DORotate(new Vector3(0, 0, 0), rotationTime/2).SetEase(Ease.Linear);
        });
    }
}
