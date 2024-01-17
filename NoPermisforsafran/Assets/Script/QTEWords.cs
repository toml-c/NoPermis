using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/QTEWords", order = 1)]
public class QTEWords : ScriptableObject
{
    public List<string> Words = new List<string>();
}