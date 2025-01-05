using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMessage : MonoBehaviour
{
    public string GameLevel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene(GameLevel);
        }
    }
}
