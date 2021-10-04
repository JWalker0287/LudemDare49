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
                SceneLoader.DoorTravel(destLevelName, destID);
            }
        }
    }

    void OnTriggerEnter2D (Collider2D c)
    {   
        PlayerController p = c.gameObject.GetComponent<PlayerController>();
        if (p == null) return;

        prompting = true;
        anim.SetBool("Opened", true);

    }

    void OnTriggerExit2D (Collider2D c)
    {
        PlayerController p = c.gameObject.GetComponent<PlayerController>();
        if (p == null) return;

        prompting = false;
        anim.SetBool("Opened", false);
    }

}
