using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameViewController : MonoBehaviour {

    private static GameViewController instance;

    public static GameViewController Instance { get { return instance; } }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
        //DontDestroyOnLoad(transform.gameObject);
    }

    public int score = 10000;
    public float decreaseRate = 0.2f;
    public bool playing = true;

    public Text scoreText;

	// Use this for initialization
	void Start () {
        StartGame();
	}

	void StartGame() {
        playing = true;
        StartCoroutine("DecreaseScore");
    }

    public void IncreaseScore(int amount) {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void OnGoalReached() {
        Debug.Log("You win");
    }
 
    IEnumerator DecreaseScore() {
        while (playing) {
            if (score > 0) {
                score -= 1;
                scoreText.text = score.ToString();
            }
            yield return new WaitForSeconds(decreaseRate);
        }
    }

}
