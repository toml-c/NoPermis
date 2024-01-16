using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombeStart : MonoBehaviour
{
    public GameObject Bomb;
    public GameObject QTEPivot;
    public float QTERelativePosition;
    public QTE QTE;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            QTEPivot.transform.position = Bomb.transform.position;
            QTEPivot.transform.position += new Vector3(0, QTERelativePosition, 0);
            QTE.WordChosen();
        }
    }
}
