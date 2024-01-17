using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController _controller;
    
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _colliderRadius;
    
    
    [Space(10)][Header("Input")]
    [SerializeField] private KeyCode _up; 
    [SerializeField] private KeyCode _down;
    [SerializeField] private KeyCode _left;
    [SerializeField] private KeyCode _right;

    private Vector3 _moveDirection;

    void Start()
    {
        _controller = gameObject.AddComponent<CharacterController>();
        _controller.radius = _colliderRadius;
    }

    void Update()
    {
        float horizontalAxis = 0;
        
        #region Input
        if (Input.GetKey (_right))
            horizontalAxis++;
        if (Input.GetKey (_left))
            horizontalAxis--;

        float verticalAxis = 0;
        if (Input.GetKey (_up))
            verticalAxis++;
        if (Input.GetKey (_down))
            verticalAxis--;
        
        //anim
        if(horizontalAxis != 0 || verticalAxis != 0)
            GetComponent<Animator>().SetBool("IsRunning", true);
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
            
        #endregion
        
        _moveDirection = new Vector3(horizontalAxis, 0, verticalAxis);
        _moveDirection.Normalize();
        _controller.Move(_moveDirection * Time.deltaTime * _playerSpeed);

        
        if (_moveDirection != Vector3.zero)
        {
            gameObject.transform.forward = _moveDirection;
        }
    }
}
