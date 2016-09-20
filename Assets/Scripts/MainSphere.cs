using UnityEngine;
using System.Collections;

public class MainSphere: Sphere {

    
    public GameObject mainCamera;
	
	void FixedUpdate () {
        if (!Input.GetButton("Shift")){
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = mainCamera.transform.TransformDirection(new Vector3(moveHorizontal, 0.0f, moveVertical));
            movement.y = 0;
            rb.AddForce(movement * speed);
        }
	}
}
