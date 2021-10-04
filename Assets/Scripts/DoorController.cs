using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int doorID = 0;
    public int destID = 0;
    public string destLevelName = "";
    public bool prompting = false;

    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (prompting)
        {
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("this works");
            }
        }
    }

    void OnTriggerEnter(Collider c)
    {   

        prompting = true;
        anim.SetBool("Opened", true);

    }

    void OnTriggerExit(Collider c)
    {
        prompting = false;
        anim.SetBool("Opened", false);
    }

}
