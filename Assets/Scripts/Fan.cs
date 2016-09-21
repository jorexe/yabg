using UnityEngine;
using System.Collections;

public class Fan : MonoBehaviour {

    public float force;
    public GameObject rotator;
    public int rotationSpeed;

    void Update() {
        rotator.transform.Rotate(new Vector3(0f, rotationSpeed, 0f));
    }

	void OnTriggerStay (Collider other) {
        Sphere sphere = other.gameObject.GetComponent<Sphere>();
        if (sphere != null) {
            sphere.rb.AddForce(new Vector3(0f, force, 0f));
        }
    }
}
