using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

            StartCoroutine(GetHitted(other.gameObject));
        }
    }
    IEnumerator GetHitted(GameObject other)
    {
        other.gameObject.GetComponent<Animator>().SetBool("IsHitted", true);
        yield return new WaitForSeconds(0.1f);
        other.gameObject.GetComponent<Animator>().SetBool("IsHitted", false);
    }
    private static bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
