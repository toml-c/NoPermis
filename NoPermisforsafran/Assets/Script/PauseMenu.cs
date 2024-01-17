using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject MenuPause;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            MenuPause.SetActive(true);
        }
    }

    public void OnClickContinue()
    {
        Time.timeScale = 1;
        MenuPause.SetActive(false);
    }

    public void OnClikQuit()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}