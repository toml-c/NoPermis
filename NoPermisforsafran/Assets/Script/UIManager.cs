using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public static UIManager instance;

    public int Gold;

    public float TimerMax;
    float _currentTimer;
    bool _isGameOver;
    Image _timerDisplay;
    [SerializeField]
    TMP_Text _timerText;
    public TMP_Text GoldText;

    /*private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is already another UI script in this scene !");
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        _timerDisplay = GetComponent<Image>();
        _currentTimer = TimerMax;
    }

    // Update is called once per frame
    void Update()
    {

        _timerText.text = ((int)_currentTimer).ToString();
        _timerDisplay.fillAmount = _currentTimer / TimerMax;
        if (!_isGameOver)
        {
            _currentTimer -= Time.deltaTime;
        }
        if (_currentTimer < 0 && _isGameOver == false)
        {
            _isGameOver = true;
            GameOver();
        }
    }

    private void GameOver()
    {
        print("dead");

    }
}
