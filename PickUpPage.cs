using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPage : MonoBehaviour
{
    public GameObject collectTextObj, intText, monoText;
    public AudioSource pickupSound, ambiance;
    public bool interactable;
    public static int pagesCollected;
    public Text collectText;

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
        monoText.SetActive(false);
        interactable = false;
    }

    private void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            { 
                pagesCollected = pagesCollected + 1;
                collectText.text = pagesCollected + "/8 pages";
                monoText.SetActive(true);
                collectTextObj.SetActive(true);
                pickupSound.Play();
                intText.SetActive(false);
                this.gameObject.SetActive(false);
                interactable = false;
            }
        }

        if (pagesCollected == 8) 
        { 
            ambiance.Pause();
        }
    }
}
