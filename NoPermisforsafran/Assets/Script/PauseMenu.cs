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

}
