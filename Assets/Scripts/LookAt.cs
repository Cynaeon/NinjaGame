﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(transform.position + UnityEngine.Camera.main.transform.rotation * Vector3.forward,
            UnityEngine.Camera.main.transform.rotation * Vector3.up);
	}
}
