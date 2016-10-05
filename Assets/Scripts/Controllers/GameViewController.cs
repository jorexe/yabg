using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public bool paused = false;

    public GameObject levelWonPanel;
    public GameObject playerDiedPanel;
    public GameObject pausePanel;
    public Text scoreLabel;

    public Text scoreText;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }

        currentLevel = null;
        currentLevelIdx = 0;
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

    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape) && !paused) {
            paused = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnUnpauseClicked() {
        paused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnExitMenuClicked() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void IncreaseScore(int amount) {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void OnGoalReached() {
        playing = false;
        SetSphereActive(false);
        levelWonPanel.SetActive(true);
        scoreLabel.text = score.ToString();
    }

    private void SetSphereActive(bool active) {
        FindObjectOfType<MainSphere>().gameObject.SetActive(active);
    }

    public void OnContinueClicked() {
        if (currentLevelIdx == levelPrefabs.Length - 1) {
            OnExitMenuClicked();
            return;
        }

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
        SetSphereActive(false);
        playerDiedPanel.SetActive(true);
    }
 
    IEnumerator DecreaseScore() {
        while (playing) {
            if (score > 0 && !paused) {
                score -= 1;
                scoreText.text = score.ToString();
            }
            yield return new WaitForSeconds(decreaseRate);
        }
    }

}
