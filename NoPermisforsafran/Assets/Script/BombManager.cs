using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{

    public GameObject BombPrefab;
    public int RadiusSize;

    [SerializeField] private LayerMask _whatToHit;
    private GameObject _lastestBomb;
    bool _isThereBomb = false;
    float _timerMax;
    float _timer = 0;


    private void Awake()
    {
    }

    // Start is called before the first frame update
    public void Start()
    {
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
            Collider[] col = Physics.OverlapSphere(_lastestBomb.transform.position, RadiusSize, _whatToHit);

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
        _lastestBomb = Instantiate(BombPrefab, transform.position + (transform.forward * 2), Quaternion.identity);
        _timer = 4f;
        _timerMax = _timer;
        _isThereBomb = true;
    }

}
