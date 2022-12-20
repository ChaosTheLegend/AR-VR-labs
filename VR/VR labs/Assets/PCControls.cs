using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCControls : MonoBehaviour
{
    [SerializeField]
    private List<PCHammerController> hammers;
    
    public void PlayHammer(int hammerIndex)
    {
        hammers[hammerIndex].DoRotation();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayHammer(0);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayHammer(1);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayHammer(2);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayHammer(3);
        }
        
    }
}
