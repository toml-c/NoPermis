using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombVisual : MonoBehaviour
{

    Animator anim;
    public bool bomb0;
    public bool bomb1;
    public bool bomb2;
    public bool bomb3;
    public bool Explode;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bomb0)
        { anim.SetTrigger("Bomb0");
            Reset();
            bomb0 = false;
        }
        else
        {
            anim.ResetTrigger("Bomb0");
            bomb0 = false;
        }
        if (bomb1)
        { anim.SetTrigger("Bomb1");
            bomb0 = false;
        }
        else
        {
            bomb1 = false;
            anim.ResetTrigger("Bomb1");
        }
        if (bomb2)
        { anim.SetTrigger("Bomb2"); }
        else
        {
            bomb2 = false;
            anim.ResetTrigger("Bomb2");

        }
        if (bomb3)
        { anim.SetTrigger("Bomb3"); }
        else
        {
            
            anim.ResetTrigger("Bomb3");
        }

    }
    private void Reset()
    {
        bomb1 = false;
        bomb2 = false;
        bomb3 = false;
    }
}
