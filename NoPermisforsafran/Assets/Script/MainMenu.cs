using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public List<GameObject> ButtonsMenu = new List<GameObject>();
    public List<GameObject> Noms = new List<GameObject>();
    public Image Fade;


    private void Start()
    {
        Fade.enabled = false;
    }

    public void OnClickPlay()
    { 
        StartCoroutine(FadingPlay());
    }


    public void OnClickQuit()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        StartCoroutine(FadingQuit());
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnClickCredits()
    {
        for (int i = 0; i < ButtonsMenu.Count; i++)
        {
            ButtonsMenu[i].SetActive(false);
        }

        for (int i = 0; i < Noms.Count; i++)
        {
            Noms[i].SetActive(true);
        }
    }

    public void OnClickReturns()
    {
        for (int i = 0; i < Noms.Count; i++)
        {
            Noms[i].SetActive(false);
        }

        for (int i = 0; i < ButtonsMenu.Count; i++)
        {
            ButtonsMenu[i].SetActive(true);
        }
    }


    

    IEnumerator FadingPlay()
    {
        Fade.enabled = true;
        Fade.DOFade(1, 2);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SCENE_FINALE");
    }

    IEnumerator FadingQuit()
    {
        Fade.enabled = true;
        Fade.DOFade(1, 2);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SCENE_FINALE");
    }

}
