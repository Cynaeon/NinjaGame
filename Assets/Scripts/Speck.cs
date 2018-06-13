using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speck : MonoBehaviour {

    public float launchSpeed;
    public float collectedSpeed;

    private float lifetime;
    private bool collected;
    private Rigidbody rb;
    private Transform player;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Vector3 dir = new Vector3(Random.Range(-0.5f, 0.5f), 0.5f, Random.Range(-0.5f, 0.5f)); 
        rb.AddForce(dir * launchSpeed);

        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        lifetime += Time.deltaTime;
		if (collected && lifetime > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, collectedSpeed * Time.deltaTime);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vacuum")
        {
            collected = true;
        }
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            ExpSystem.GainExp(1);
            Destroy(gameObject);
        }
    }
}
