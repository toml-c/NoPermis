using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public static Bomb instance;
    
    public GameObject ActualBomb;
    public GameObject QTEPivot;
    public Vector3 QTERelativePosition;
    public QTE QTE;
    [HideInInspector] public bool CanChooseWord;
    public int GoldLostByHit;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is already another Bomb script in this scene !");
        }
    }

    private void Update()
    {
        if (ActualBomb != null)
        {
            QTEPivot.SetActive(true);
            QTEPivot.transform.position = ActualBomb.transform.position;
            QTEPivot.transform.position += new Vector3(QTERelativePosition.x, QTERelativePosition.y, QTERelativePosition.z);

            if (CanChooseWord)
            {
                CanChooseWord = false;   
                QTE.WordChosen();
            }
        }
        else
        {
            QTEPivot.SetActive(false);
        }
    }
}