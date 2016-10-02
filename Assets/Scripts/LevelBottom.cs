using UnityEngine;
using System.Collections;

public class LevelBottom : MonoBehaviour {

    private bool isEnabled = true;

    public void Toggle() {
        isEnabled = !isEnabled;
    }

    void OnTriggerEnter(Collider other) {
        if (!isEnabled) {
            return;
        }

        MainSphere sphere = other.gameObject.GetComponent<MainSphere>();
        if (sphere != null) {
            GameViewController.Instance.OnPlayerDied();
            Toggle();
        }
    }
}