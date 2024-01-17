using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public int GoldEarn;
    public LayerMask TargetLayer;
    public List<Mesh> Meshs;
    public List<Material> MaterialsSquare;
    public List<Material> MaterialsCircle;
    public List<Material> MaterialsRectangle;

    private void Start()
    {
        if (tag == "Paint")
        {
            var i = Random.RandomRange(0, Meshs.Count);
            //Debug.Log(i);
            GetComponent<MeshFilter>().mesh = Meshs[i];
            switch (i)
            {
                case 0:
                    var j = Random.RandomRange(0, MaterialsSquare.Count);
                    GetComponent<Renderer>().material = MaterialsSquare[j];
                    break;
                case 1:
                    var jj = Random.RandomRange(0, MaterialsCircle.Count);
                    GetComponent<Renderer>().material = MaterialsCircle[jj];
                    break;
                case 2:
                    var jjj = Random.RandomRange(0, MaterialsRectangle.Count);
                    GetComponent<Renderer>().material = MaterialsRectangle[jjj];
                    break;
            }
        }
        //GetComponent<Renderer>().material = Materials[i];
    }

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
