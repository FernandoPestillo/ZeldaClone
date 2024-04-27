using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public float _swordDamage = 1f;
    public Collider2D swordCollider;

    void Start()
    {
        if(swordCollider == null)
        {
            Debug.LogWarning("Deu bosta");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Colisao" + col);

        Debug.Log("Collider: " + col.collider);

        col.collider.SendMessage("OnHit", _swordDamage);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
