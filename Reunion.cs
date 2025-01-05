using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Reunion : MonoBehaviour
{
    public GameObject intText;
    public bool interactable;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        intText.SetActive(false);
        interactable = false;
    }

    public void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                float randomValue = Random.value;

                if (randomValue >= 0.0f && randomValue <= 0.25f)
                {
                    SceneManager.LoadScene(3);
                }
                if (randomValue > 0.25f && randomValue <= 0.50f)
                {
                    SceneManager.LoadScene(4);
                }
                if (randomValue > 0.50f && randomValue <= 0.75f)
                {
                    SceneManager.LoadScene(5);
                }
                if (randomValue > 0.75f && randomValue <= 1.0f)
                {
                    SceneManager.LoadScene(6);
                }
            }
        }
    }
}
