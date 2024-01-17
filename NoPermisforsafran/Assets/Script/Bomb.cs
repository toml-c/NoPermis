using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject QTEPivot;
    public float QTERelativePosition;
    public QTE QTE;

    private void Start()
    {
        QTEPivot.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        QTEPivot.transform.position += new Vector3(0, QTERelativePosition, 0);
        QTE.WordChosen();
    }
}