using UnityEngine;

public class VictoryChecker : MonoBehaviour
{
    public GameObject _feedBackInput;

    [Space(10)]
    [Header("Debug")]
    //[SerializeField] private bool _isStolen = false;
    [SerializeField] private int _playerCount = 0;

    private bool _leftPressed = false;
    private bool _rightPressed = false;

    private void Update()
    {
        _feedBackInput.SetActive(_playerCount != 0);


        if (_playerCount != 0)
        {

            if (_rightPressed == false && Input.GetKeyDown(KeyCode.RightControl))
            {
                _rightPressed = true;
            }

            if (_leftPressed == false && Input.GetKeyDown(KeyCode.LeftControl))
            {
                _leftPressed = true;
            }

            if (_rightPressed == true && _leftPressed == true)
            {
                Debug.Log("You Won!");
            }
        }

    }


    private void OnTriggerEnter(Collider collision)
    {
        _playerCount++;

        if (collision.gameObject.name == "Player1")
        {
            BombManager.instance.BombPermited = false;
        }
    }

   

    private void OnTriggerExit(Collider collision)
    {
        _playerCount--;

        if (_playerCount == 0 || collision.gameObject.name == "Player2")
        {
            BombManager.instance.BombPermited = true;
        }
    }

    private static bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}