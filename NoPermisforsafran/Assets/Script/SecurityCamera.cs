using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public LayerMask TargetLayer;

    bool _isInvincible = false;
    float _invincibleTime;


    private void Update()
    {
        if (_invincibleTime > 0)
        {
            _invincibleTime -= Time.deltaTime;
        }

        if (_invincibleTime <= 0)
        {
            _isInvincible = false;
        }



    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character1" || other.gameObject.name == "Character2" && _isInvincible == false)
        {
            UIManager.instance._currentTimer -= 8f;
            _isInvincible = true;
            _invincibleTime = 2.5f;

        }
        
    }
}
