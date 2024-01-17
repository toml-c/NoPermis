using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AfterGame : MonoBehaviour
{

    public Image Fading;

    void Start()
    {
        StartCoroutine(FadingIn());
    }

    IEnumerator FadingIn()
    {
        Fading.DOFade(0, 3);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("SCENE_MENU");
    }
}
