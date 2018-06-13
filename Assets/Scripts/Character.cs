using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public int health = 2;
    public float movementSpeed = 8;
    public float gravity = 20f;
    public int damageKnockback = 800;

    protected virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (GetComponent<Rigidbody>()) 
            GetComponent<Rigidbody>().AddForce(-transform.forward * damageKnockback);
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
