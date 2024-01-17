using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkZone : MonoBehaviour
{
    public GameObject Zone;
    public int NbMax;
    public List<GameObject> Blocks;

    private void Start()
    {
        NbMax = Blocks.Count;
    }
    void Update()
    {
        if (Blocks.Count < NbMax)
        {
            Zone.SetActive(false);
        }
    }
}
