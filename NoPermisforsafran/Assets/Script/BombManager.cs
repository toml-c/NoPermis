using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public static BombManager instance;
    public GameObject BombPrefab;
    public int RadiusSize;
    public bool BombPermited = true;

    [SerializeField] private LayerMask _whatToHit;
    private GameObject _lastestBomb;
    float _timerMax;
    float _timer = 0;


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

    // Start is called before the first frame update
    public void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (BombPermited == true)
        {
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                Create();
            }
        }
        

        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }

        else if (_timer <= 0 && BombPermited == false)
        {
            /*
            Collider[] col = Physics.OverlapSphere(_lastestBomb.transform.position, RadiusSize, _whatToHit);

            foreach (var item in col)
            {
                Destroy(item.gameObject);
            }
            */

            foreach (Transform t in _lastestBomb.transform) 
            { 
                t.gameObject.SetActive(true);
            }

            Destroy(_lastestBomb, 0.2f);
            _timer = 0;
            BombPermited = true;
        }
    }

    void Create()
    {
        _lastestBomb = Instantiate(BombPrefab, transform.position + (transform.forward * 2), Quaternion.identity);
        _timer = 4f;
        _timerMax = _timer;
        BombPermited = false;
    }

}
