using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject ActualBomb;
    public GameObject QTEPivot;
    public float QTERelativePosition;
    public QTE QTE;
    public bool CanChooseWord;

    private void Update()
    {
        if (ActualBomb != null)
        {
            QTEPivot.transform.position = ActualBomb.transform.position;
            QTEPivot.transform.position += new Vector3(0, QTERelativePosition, 0);

            if (CanChooseWord)
            {
                CanChooseWord = false;   
                QTE.WordChosen();
            }
        }
    }
}