using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{

    public GameObject BombPrefab;
    public float ColliderSize;
    [SerializeField] private LayerMask whatToHit;

    private GameObject _lastestBomb;
    bool _isThereBomb = false;
    float _timerMax;
    float _timer = 0;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        _boxCollider.size = ColliderSize * Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {

            Create();
        }

        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }

        else if (_timer <= 0 && _isThereBomb)
        {
            Collider[] col = Physics.OverlapSphere(_lastestBomb.transform.position, 6, whatToHit);

            foreach (var item in col)
            {
                Destroy(item.gameObject);
            }

            Destroy(_lastestBomb);
            _timer = 0;
            _isThereBomb = false;
        }
    }

    void Create()
    {
        _lastestBomb = Instantiate(BombPrefab, transform.position, Quaternion.identity);
        _timer = 4f;
        _timerMax = _timer;
        _isThereBomb = true;
    }

}
