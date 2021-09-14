using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button _button;
    private GameManager _gameManager;
    [SerializeField] public int difficulty;
    [SerializeField] public float waitTime;

    void Start() {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    void Update() { }

    void SetDifficulty() {
        _gameManager.StartGame(difficulty);
    }
}
