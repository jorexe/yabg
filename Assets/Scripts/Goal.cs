using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    private Vector3 initialPosition;

    void Start() {
        initialPosition = transform.position;
    }

    void Update() {
        float offset = Mathf.Sin(Time.time * 5);

        transform.position = new Vector3(initialPosition.x, initialPosition.y + offset / 4, initialPosition.z);

        float scale = 0.3f + (0.5f + Mathf.Sin(Time.time * 2) / 6);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    void OnTriggerStay(Collider other) {
        if (!enabled) {
            return;
        }

        Sphere sphere = other.gameObject.GetComponent<Sphere>();
        if (sphere != null) {
            GameViewController gameViewController = FindObjectOfType<GameViewController>();

            if (gameViewController != null) {
                gameViewController.OnGoalReached();
            }

            enabled = false;
        }
    }
}
