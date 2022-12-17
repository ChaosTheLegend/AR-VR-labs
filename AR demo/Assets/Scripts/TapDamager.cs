using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDamager : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private Camera camera;
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        //do raycast on Enemy layer
        if (Physics.Raycast(ray, out var hit, 100, LayerMask.GetMask("Enemy")))
        {
            //if raycast hits enemy, damage it
            hit.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
