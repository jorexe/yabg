using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    private enum Direction {
        LEFT, RIGHT
    }

    public GameObject player;

    private Vector3 offset;

    private bool updateCamera = false;

	void Start () {
        offset = transform.position - player.transform.position;
        transform.LookAt(player.transform);
    }

    void Update() {
        
        if (Input.GetButton("Shift")) {
            if (Input.GetAxis("Horizontal") == 0) {
                updateCamera = true;
            }
            else if (Input.GetAxis("Horizontal") > 0 && updateCamera) {
                rotateCamera(Direction.RIGHT);
                updateCamera = false;
                Debug.Log("Rotation -90");
            } else if (Input.GetAxis("Horizontal") < 0 && updateCamera) {
                rotateCamera(Direction.LEFT);
                updateCamera = false;
                Debug.Log("Rotation 90");
            }
        }
    }
	
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}

    private void rotateCamera(Direction direction) {
        switch(direction) {
            case Direction.LEFT:
                transform.Translate(Vector3.left * Time.deltaTime);
                transform.LookAt(player.transform);
                break;
            case Direction.RIGHT:

                break;
        }
    }
}
