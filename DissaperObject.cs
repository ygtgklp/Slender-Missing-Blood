using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DissaperObject : MonoBehaviour
{
    SlenderManAI slenderManAI;
    public GameObject Slender;

    public GameObject Obj;
    public float activeTime;
    public float waitTime;


    void Start()
    {
        StartCoroutine(waiter());
        slenderManAI = Slender.GetComponent<SlenderManAI>();
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(waitTime);
        Obj.SetActive(true);
    }

    private void Update()
    {
        if (Obj.active == true)
        {
            StartCoroutine(Disableobj());
        }
    }

    IEnumerator Disableobj() 
    {
        yield return new WaitForSeconds(activeTime);
        Obj.SetActive(false);
        slenderManAI.chaseProbability = slenderManAI.chaseProbability + 0.2f;
    }

}
