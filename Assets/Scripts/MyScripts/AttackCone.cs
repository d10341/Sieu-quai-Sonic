using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone : MonoBehaviour
{
    public Tower turret;



    private void Awake()
    {
        turret = gameObject.GetComponentInParent<Tower>();

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            turret.Attack();
        }
    }
}
