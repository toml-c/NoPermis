using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject MenuPause;
    public int Gold;
    public Image TimerImage;
    public Image Fade;

    public float TimerMax;
    public float _currentTimer;
    bool _isGameOver;
    Image _timerDisplay;
    [SerializeField]
    TMP_Text _timerText;
    public TMP_Text GoldText;

    private void Awake()
    {
        Fade.DOFade(0, 3);
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
        if (Gold <= 0)
            Gold = 0;
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
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        Fade.DOFade(1, 3);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("SCENE_GAMEOVER");
    }



}