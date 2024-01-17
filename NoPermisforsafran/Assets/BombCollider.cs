using UnityEngine;

public class BombCollider : MonoBehaviour
{
    public LayerMask TargetLayer;

    public LayerMask PlayerLayer;
    
    private void OnTriggerEnter(Collider other)
    {
        if (Contains(TargetLayer, other.gameObject.layer))
        {
            Destroy(other.gameObject);
        }
        
        if (Contains(PlayerLayer, other.gameObject.layer))
        {
            UIManager.instance.Gold -= Bomb.instance.GoldLostByHit;
        }
    }

    private static bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
