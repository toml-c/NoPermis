using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public int GoldEarn;
    public LayerMask TargetLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (Contains(TargetLayer, other.gameObject.layer))
        {
            other.GetComponent<Character>();
            Destroy(gameObject);

            UIManager.instance.Gold += GoldEarn;
        }
    }

    private static bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
