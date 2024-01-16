using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public LayerMask TargetLayer;
    [SerializeField] private float _invincibleTimeMax;
    
    private float _invicibleTime;
    private bool _isInvincible = false;
    
    private void Update()
    {
        if (_invicibleTime > 0)
        {
            _invicibleTime -= Time.deltaTime;
        }

        if (_invicibleTime <= 0)
        {
            _isInvincible = false;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (Contains(TargetLayer, other.gameObject.layer) && _isInvincible == false)
        {
            UIManager.instance._currentTimer -= 8f;
            _isInvincible = true;
            _invicibleTime = _invincibleTimeMax;
        }
    }
    
    private static bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
