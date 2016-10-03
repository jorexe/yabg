using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameViewController : MonoBehaviour {

    private static GameViewController instance;

    public static GameViewController Instance { get { return instance; } }

    private const int INITIAL_SCORE = 10000;

    public LevelBottom levelBottom;
    public GameObject[] levelPrefabs;
    private GameObject currentLevel;

    private int currentLevelIdx;

    public int score = INITIAL_SCORE;
    public float decreaseRate = 0.2f;
    public bool playing = false;
    public GameObject levelWonPanel;
    public GameObject playerDiedPanel;

    public Text scoreText;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }

        currentLevel = null;
        currentLevelIdx = 0;
        //DontDestroyOnLoad(transform.gameObject);
    }

	// Use this for initialization
	void Start () {
        StartGame();
	}

	void StartGame() {
        // Reset previous state
        levelWonPanel.SetActive(false);
        score = INITIAL_SCORE;

        // Start level
        if (currentLevel != null) {
            Destroy(currentLevel);
            currentLevel = null;
        }

        currentLevel = Instantiate(levelPrefabs[currentLevelIdx]);
        playing = true;
        StartCoroutine("DecreaseScore");
    }

    public void IncreaseScore(int amount) {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void OnGoalReached() {
        playing = false;
        DisableSphere();
        levelWonPanel.SetActive(true);
    }

    private void DisableSphere() {
        FindObjectOfType<MainSphere>().gameObject.SetActive(false);
    }

    public void OnContinueClicked() {
        currentLevelIdx++;
        StartGame();
    }

    public void OnRestartClicked() {
        levelBottom.Toggle();
        // Reinstantiate the level
        // This will reset player pos, see-saw rotations, powerups, boxes, etc.
        StartGame();
        playerDiedPanel.SetActive(false);
    }

    public void OnPlayerDied() {
        playing = false;
        DisableSphere();
        playerDiedPanel.SetActive(true);
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
