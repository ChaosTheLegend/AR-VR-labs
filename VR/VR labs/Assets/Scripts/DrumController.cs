using System;
using System.Collections;
using System.Collections.Generic;
using Animations;
using UnityEngine;
using UnityEngine.Events;

public class DrumController : MonoBehaviour
{
    private DrumAnimator _animator;
    
    public UnityEvent OnDrumHit;
    private void Awake()
    {
        _animator = GetComponent<DrumAnimator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _animator.DoBeatAnimation();
        OnDrumHit?.Invoke();
    }
    
    
}
