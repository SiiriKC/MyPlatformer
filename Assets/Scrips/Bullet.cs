using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    public float Speed = 10f;

    public int Damage = 50;

    private void Update()
    {
        transform.position += transform.up * (Speed * Time.deltaTime); //Gives us up direction for the object.
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(Damage);
            }
            
        }
        
    }
}
