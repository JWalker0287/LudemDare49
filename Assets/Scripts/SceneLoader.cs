using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader sceneLoader;

    void Start()
    {
        if (sceneLoader == null) 
        {
            sceneLoader = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void ReloadCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public static void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void DoorTravel(string lvlName, int dID)
    {
        sceneLoader.StartCoroutine(sceneLoader.DoorTravelCoroutine(lvlName, dID));
    }

    public IEnumerator DoorTravelCoroutine(string lvlName, int dID)
    {
        if (lvlName == SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene(lvlName);
        }
        else 
        {
            yield return SceneManager.LoadSceneAsync(lvlName);
        }

        DoorController[] doors = GameObject.FindObjectsOfType<DoorController>();
        foreach (DoorController door in doors)
        {
            if (door.doorID == dID)
            {
                PlayerController.player.transform.position = door.transform.position;
                break;
            }
        }
    }
}
