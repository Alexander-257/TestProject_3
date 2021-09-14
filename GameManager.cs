using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject startScreen;
    [SerializeField] public GameObject difficultyScreen;
    [SerializeField] public GameObject gameScreen;
    [SerializeField] public GameObject gameOverScreen;

    [SerializeField] public Button startButton;
    [SerializeField] public Text scoreText;
    [SerializeField] public Text finalScoreText;
    [SerializeField] public float waitTime;
    [SerializeField] public bool isGameActive;
    [SerializeField] private GameObject[] cars;
    [SerializeField] public int score;

    [SerializeField] private AudioClip[] musics;
    [HideInInspector] private AudioSource music;

    void Start() { music = GetComponent<AudioSource>();  }

    void Update() { }

    public void StartScreenGame() {
        startScreen.SetActive(false);
        difficultyScreen.SetActive(true);
    }

    public void StartGame(int difficulty) {
        float[] waitTimer = new float[3] { 2.5f, 1.5f, 0.7f };
        isGameActive = true;
        waitTime = waitTimer[difficulty - 1];
        music.clip = musics[difficulty - 1];
        music.Play();
        StartCoroutine(EnemySpawner());
        difficultyScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void GameScreen() {
        difficultyScreen.SetActive(false);
    }

    public void GameOver() {
        music.Stop();
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        finalScoreText.text = "Score: " + score;
        isGameActive = false;
        StopCoroutine(EnemySpawner());
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ScoreUpdate() {
        scoreText.text = "Score: " + score;
    }

    void SpawnEnemy() {
        int index = Random.Range(0, 4);
        Instantiate(cars[index], RandomSide(), cars[index].transform.rotation);
    }

    Vector3 RandomSide() {
        int side = Random.Range(1, 3); // 1-2
        //Debug.Log("pos: " +side);
        Vector3 pos = Vector3.zero;

        if (side == 1) {
            pos = new Vector3(-1.5f, 0, 38);
        }

        if (side == 2) {
            pos = new Vector3(1.5f, 0, 38);
        }

        return pos;
    }

    IEnumerator EnemySpawner() {
        while(isGameActive) {
            yield return new WaitForSeconds(waitTime);

            SpawnEnemy();
        }
    }
}
