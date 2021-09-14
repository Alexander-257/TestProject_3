using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool _leftSide;
    [SerializeField] private bool _rightSide;

    [SerializeField] private float horizontalInput;
    [SerializeField] public GameManager gameManager;

    [SerializeField] public Joystick joystick;

    void Start() {
        _rightSide = false;
        _leftSide = true;
    }

    void Update() {
        //if(gameManager.isGameActive) {
        //    /*SideControl();*/ // 1 - варинат
        //    // or
        //    // 2 - вариант
        //    //horizontalInput = Input.GetAxis("Horizontal");
        //    //transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * 10);
        //    Border();
        //}

        if (gameManager.isGameActive) {
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = new Vector3(joystick.Horizontal * 8f,
                                            transform.position.y,
                                            transform.position.z);
            Border();
        }
        else {
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = new Vector3(joystick.Horizontal * 0f,
                                            transform.position.y,
                                            transform.position.z);
        }
    }

    public void LeftSide() {
        if (_leftSide) {
            transform.position = new Vector3(-1.5f, transform.position.y, transform.position.z);
            ChangeSide();
        }
    }

    public void RightSide() {
        if (_rightSide)
        {
            transform.position = new Vector3(1.5f, transform.position.y, transform.position.z);
            ChangeSide();
        }
    }

    void SideControl() {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            if(_leftSide) {
                transform.position = new Vector3(-1.5f, transform.position.y, transform.position.z);
                ChangeSide();
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            if (_rightSide) {
                transform.position = new Vector3(1.5f, transform.position.y, transform.position.z);
                ChangeSide();
            }
        }
    }

    void ChangeSide() {
        bool temp = _rightSide;
        _rightSide = _leftSide;
        _leftSide = temp;
    }

    void Border() {
        if(transform.position.x > 1.5f) {
            transform.position = new Vector3(1.5f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -1.5f) {
            transform.position = new Vector3(-1.5f, transform.position.y, transform.position.z);
        }
    }

    //private void OnCollisionEnter(Collision collision) {
    //    if(collision.gameObject.CompareTag("EnemyCar")) {

    //    }
    //}

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("EnemyCar")) {
            //Debug.Log("GameOver");
            gameManager.GameOver();
        }
    }
}
