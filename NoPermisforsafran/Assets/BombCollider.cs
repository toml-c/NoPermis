using UnityEngine;

public class BombCollider : MonoBehaviour
{
    public LayerMask TargetLayer;
    
    private void OnTriggerEnter(Collider other)
    {
        if (Contains(TargetLayer, other.gameObject.layer))
        {
            Destroy(other.gameObject);
        }
    }

    private static bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
