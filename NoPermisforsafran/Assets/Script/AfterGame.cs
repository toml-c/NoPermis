using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using DG.Tweening;
using UnityEngine.UI;

public class AfterGame : MonoBehaviour
{

    public Image Fading;

    void Start()
    {
        Fading.DOFade(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
