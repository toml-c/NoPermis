using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject MenuPause;
    public int Gold;
    public Image TimerImage;

    public float TimerMax;
    public float _currentTimer;
    bool _isGameOver;
    Image _timerDisplay;
    [SerializeField]
    TMP_Text _timerText;
    public TMP_Text GoldText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is already another UI script in this scene !");
        }
    }

    void Start()
    {
        _timerDisplay = TimerImage;
        _currentTimer = TimerMax;
    }

    void Update()
    {
        GoldText.text = "Gold : " + Gold;

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