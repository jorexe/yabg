using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

	void Start () {
        offset = transform.position - player.transform.position;
        transform.LookAt(player.transform);
    }

}
