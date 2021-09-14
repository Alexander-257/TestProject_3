using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float borderPoint;
    [SerializeField] public float zPoint = 38.0f;
    [SerializeField] public GameManager gameManager;

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update() {
        if(gameManager.isGameActive) {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if(transform.position.z < borderPoint) {
            if(gameObject.CompareTag("EnemyCar")) { // For cars
                Destroy(gameObject);
                gameManager.score++;
                gameManager.ScoreUpdate();
                //Debug.Log("score: " + gameManager.score);
            }
            else {
                transform.position = new Vector3(transform.position.x, transform.position.y, zPoint); // For not cars
            }
        }
    }
}
