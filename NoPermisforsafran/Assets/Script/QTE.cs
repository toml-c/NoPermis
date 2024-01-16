using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QTE : MonoBehaviour
{
    public TextMeshProUGUI QTEText;
    public List<string> QTEWords = new List<string>();
    public QTEPlayer QTEPlayer;

    public void WordChosen()
    {
        var WRand = Random.Range(0, QTEWords.Count);
        QTEText.text = QTEWords[WRand];
        QTEPlayer.TextBase = QTEWords[WRand];
        QTEPlayer.NumberLetter = QTEText.text.Length;
    }
}
