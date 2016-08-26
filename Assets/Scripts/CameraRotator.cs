using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour {

    public GameObject player;
    public float speed;
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
        if (Input.GetButton("Shift")) {
            if (Input.GetAxis("Horizontal") > 0) {
                transform.Rotate(new Vector3(0f, -speed * Time.deltaTime,0f));

            }
            else if (Input.GetAxis("Horizontal") < 0) {
                transform.Rotate(new Vector3(0f, speed * Time.deltaTime, 0f));
            }
        }
    }
}
