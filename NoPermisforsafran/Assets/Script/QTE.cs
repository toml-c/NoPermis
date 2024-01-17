using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QTE : MonoBehaviour
{
    public TextMeshProUGUI QTEText;
    public List<QTEWords> QTEList = new List<QTEWords>();
    public QTEPlayer QTEPlayer;

    public void WordChosen()
    {
        var WRand = Random.Range(0, QTEList[0].Words.Count);
        QTEText.text = QTEList[BombManager.instance._nbRecursiveBomb - 1].Words[WRand];
        QTEPlayer.TextBase = QTEList[BombManager.instance._nbRecursiveBomb - 1].Words[WRand];
        QTEPlayer.NumberLetter = QTEText.text.Length;
    }
}