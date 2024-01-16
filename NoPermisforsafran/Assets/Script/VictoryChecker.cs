using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VictoryChecker : MonoBehaviour
{

    public GameObject FeedBackInput;

    bool _isStolen = false;
    bool _leftPressed = false;
    bool _rightPressed = false;
    int _playerCount = 0;

    private void Start()
    {
        FeedBackInput.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (_playerCount == 0)
            FeedBackInput.SetActive(true);

        _playerCount++;

        if (collision.gameObject.name == "Character1")
        {
            BombManager.instance.BombPermited = false;
        }

        if (_rightPressed ==false && Input.GetKeyUp(KeyCode.RightControl))
        {
            _rightPressed = true;
        }

        if (_leftPressed == false && Input.GetKeyUp(KeyCode.LeftControl))
        {
            _leftPressed = true;
        }


        if (_rightPressed == true && _leftPressed == true)
        {
            Debug.Log("You Won!");
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        _playerCount--;

        if (_playerCount == 0)
            FeedBackInput.SetActive(false);

        if (_playerCount == 0 || collision.gameObject.name == "Character2")
        {
            BombManager.instance.BombPermited = true;
        }

    }
}
