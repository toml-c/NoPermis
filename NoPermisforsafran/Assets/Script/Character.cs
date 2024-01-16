using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float playerSpeed;
    CharacterController controller;
    public float colliderRadius;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    private Vector3 _moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        controller.radius = colliderRadius;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = 0;
        if (Input.GetKey (right))
            horizontalAxis++;
        if (Input.GetKey (left))
            horizontalAxis--;

        float verticalAxis = 0;
        if (Input.GetKey (up))
            verticalAxis++;
        if (Input.GetKey (down))
            verticalAxis--;

        _moveDirection = new Vector3(horizontalAxis, 0, verticalAxis);
        _moveDirection.Normalize();
        controller.Move(_moveDirection * Time.deltaTime * playerSpeed);

        if (_moveDirection != Vector3.zero)
        {
            gameObject.transform.forward = _moveDirection;
        }

    }


}
