using UnityEngine;
using System.Collections;

public class ScoreItem : MonoBehaviour {

    public int scoreAmount;

    void OnTriggerEnter(Collider other) {
        MainSphere sphere = other.gameObject.GetComponent<MainSphere>();
        if (sphere != null) {
            GameViewController.Instance.IncreaseScore(scoreAmount);
            Destroy(this.gameObject);
        }
    }
}