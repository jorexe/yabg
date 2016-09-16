using UnityEngine;
using System.Collections;

public class MainSphere: Sphere {

    
    public GameObject mainCamera;
	
	void FixedUpdate () {
        if (!Input.GetButton("Shift")){
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(mainCamera.transform.TransformDirection(movement) * speed);
        }
	}
}
