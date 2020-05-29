using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    public AudioSource speech;

    private bool didTalk = false;

    public Animator anim;

    bool doorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Talk()
    {
        if (didTalk == false)
        { 
            speech.Play();
            didTalk = true;
        }
        else
        {
            if (doorOpen == false)
            { 
                doorOpen = true;
                anim.SetTrigger("Open");
            }
            else
            {
                doorOpen = false;
                anim.SetTrigger("Close");
            }
        }
    }

}
