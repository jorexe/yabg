using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour {

    public GameObject player;
    public float speed;
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
        float axisMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Shift") && axisMovement != 0) {
            float direction = Mathf.Sign(axisMovement);
            transform.Rotate(new Vector3(0f, direction * speed * Time.deltaTime, 0f));
        }
    }
}
