using UnityEngine;

public class BombManager : MonoBehaviour
{
    public static BombManager instance;

    [Header("References")] [SerializeField]
    private GameObject _player1;
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _bombRange;
    public bool BombPermited;

    [Space(10)][Header("Bomb Properties Debug")]
    [SerializeField] private GameObject _lastestBomb;
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
    }

    void Update()
    {
        if (BombPermited)
        {
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                CreateBomb();
            }
        }
        else
        {
            _currentTimer -= Time.deltaTime;
        }
        
        if (_currentTimer <= 0)
        {
            Collider[] col = Physics.OverlapSphere(_lastestBomb.transform.position, _bombRange, _targetLayer);

            foreach (var item in col)
            {
                Destroy(item.gameObject);
            }

            foreach (Transform t in _lastestBomb.transform)
            {
                t.gameObject.SetActive(true);
            }

            Destroy(_lastestBomb, 0.2f);

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
            _nbRecursiveBomb = 0;
        }
    }

    private void CreateBomb()
    {
        _lastestBomb = Instantiate(_bombPrefab, _player1.transform.position, Quaternion.identity);
        BombPermited = false;
        
        //Recursive bomb
        if (_isRecursive)
        {
            _nbRecursiveBomb++;
        }
        
        _isRecursive = true;
        _currentTimerRecursive = _timerRecursiveMax;
    }
}