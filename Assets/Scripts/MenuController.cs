using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneLoader.LoadLevel("Level1");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
