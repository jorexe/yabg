using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    private enum Direction {
        LEFT, RIGHT
    }

    //Camera rotating values
    public float rotationSpeed;
    private bool rotating = false;
    private Direction direction;


    public GameObject player;
    private Vector3 offset;

	void Start () {
        offset = transform.position - player.transform.position;
        transform.LookAt(player.transform);
    }

    void Update() {
        //if (Input.GetButton("Shift") && !rotating) {
        //    if (Input.GetAxis("Horizontal") > 0 && !rotating) {
        //        direction = Direction.RIGHT;
        //        rotating = true;    
        //    } else if (Input.GetAxis("Horizontal") < 0 && !rotating) {
        //        direction = Direction.LEFT;
        //        rotating = true;
        //    }
        //}
        //if (rotating) {
            
        //}
    }
	
	//void LateUpdate () {
 //       transform.position = player.transform.position + offset;
	//}

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
