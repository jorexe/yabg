﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;
    public SphereMaterial sphereMaterial = SphereMaterial.WOOD;

    private Rigidbody rb;
    public GameObject mainCamera;

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        if (!Input.GetButton("Shift")){
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(mainCamera.transform.TransformDirection(movement) * speed);
        }
	}
}
