using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public float moveSpeed;
    public float zoomSpeed;
    public int maxZoom;
    public int minZoom;


    private Transform player;
    private float zoom;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 endPosition = new Vector3(player.position.x, player.position.y, player.position.z);
        transform.position = Vector3.Lerp(transform.position, endPosition + offset, moveSpeed * Time.deltaTime);
	}

    public void Zoom (float amount)
    {
        zoom += amount * zoomSpeed;
        zoom = Mathf.Clamp(zoom, maxZoom, minZoom);
        offset = transform.forward * zoom;
    }


}
