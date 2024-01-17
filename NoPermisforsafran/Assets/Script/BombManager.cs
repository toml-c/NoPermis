using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public static BombManager instance;

    [Header("References")] 
    [SerializeField] private Bomb bomb;
    [SerializeField] private GameObject _player1;
    public GameObject _player2;
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private GameObject _areabombPrefab;
    [SerializeField] private LayerMask _targetLayer;
    public bool BombPermited;
    public bool BombCanExplose;

    [Space(10)][Header("Bomb Properties Debug")]
    public GameObject _lastestBomb;
    public GameObject _previewBomb;
    [SerializeField] private float _timerMax;
    [SerializeField] private float _currentTimer;

    [Space(10)] [Header("Recursive Bomb")] 
    [SerializeField] private float _timerRecursiveMax;
    [SerializeField] private float _currentTimerRecursive;
    [SerializeField] private bool _isRecursive;
    public int _nbRecursiveBomb;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is already another UI script in this scene !");
        }
    }

    private void Start()
    {
        _currentTimer = _timerMax;
        _currentTimerRecursive = _timerRecursiveMax;
        BombPermited = true;
        _nbRecursiveBomb = 1;
    }

    IEnumerator PosingBomb()
    {
        _player1.GetComponent<Animator>().SetBool("IsPosingBomb", true);
        yield return new WaitForSeconds(0.3f);
        _player1.GetComponent<Animator>().SetBool("IsPosingBomb", false);
    }
    void Update()
    {
        if (BombPermited)
        {
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                CreateBomb();
                StartCoroutine(PosingBomb());
            }
        }
        if(_lastestBomb != null)
        {
            _currentTimer -= Time.deltaTime;
        }

        if (BombCanExplose)
        {
            BombCanExplose = false;
            
            foreach (Transform t in _lastestBomb.transform)
            {
                t.gameObject.SetActive(true);
            }

            Destroy(_lastestBomb, 0.2f);
            Destroy(_previewBomb, 0.2f);
            
            BombPermited = true;
            _currentTimer = _timerMax;
        }
        
        if (_currentTimer <= 0)
        {
            Destroy(_lastestBomb);
            Destroy(_previewBomb);
            
            BombPermited = true;
            _currentTimer = _timerMax;
        }

        //Recursive
        if (_isRecursive)
        {
            _currentTimerRecursive -= Time.deltaTime;
        }

        if (_currentTimerRecursive <= 0)
        {
            _isRecursive = false;
            _nbRecursiveBomb = 1;
        }
    }

    private void CreateBomb()
    {
        _lastestBomb = Instantiate(_bombPrefab, new Vector3(_player1.transform.position.x, _player1.transform.position.y + 0.7f, _player1.transform.position.z), Quaternion.identity);
        _previewBomb = Instantiate(_areabombPrefab,new Vector3(_player1.transform.position.x, _player1.transform.position.y + 0.72f, _player1.transform.position.z), Quaternion.identity);
        BombPermited = false;

        bomb.ActualBomb = _lastestBomb;
        bomb.CanChooseWord = true;
        
        //Recursive bomb
        if (_isRecursive && _nbRecursiveBomb < 5)
        {
            _nbRecursiveBomb++;
        }
        
        _isRecursive = true;
        _currentTimerRecursive = _timerRecursiveMax;
    }
}