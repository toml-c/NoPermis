using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject ActualBomb;
    public GameObject QTEPivot;
    public Vector3 QTERelativePosition;
    public QTE QTE;
    [HideInInspector] public bool CanChooseWord;

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