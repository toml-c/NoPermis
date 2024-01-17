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
        foreach (var block in Blocks)
        {
            if (block == null)
            {
                Zone.SetActive(false);
            }
        }
    }
}
