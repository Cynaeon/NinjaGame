using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character { 

    public float stunDuration;
    public ParticleSystem p_death;
    public GameObject speck;

    private float c_stunDuration;
    private bool stunned;
    private Transform player; 

	void Start () {
        player = FindObjectOfType<Player>().transform;
	}
	
	void Update () {
        if (stunned)
        {
            c_stunDuration += Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, transform.position - target.position, speed * 5 * Time.deltaTime);
            if (c_stunDuration > stunDuration)
                stunned = false;
        }
        else
        {
            Vector3 target = new Vector3(player.position.x, 1, player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
            transform.LookAt(target);
        }
	}

    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        stunned = true;
        if (health <= 0)
        {
            Instantiate(p_death, transform.position, Quaternion.identity);
            Instantiate(speck, transform.position, Quaternion.identity);
            Instantiate(speck, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            TakeDamage(1);
        }
    }
}
