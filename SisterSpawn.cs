using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisterSpawn : MonoBehaviour
{
    SlenderManAI slenderManAI;
    public GameObject Slender;

    Reunion reunion;
    public GameObject Sister;

    void Start()
    {
        slenderManAI = Slender.GetComponent<SlenderManAI>();
        reunion = Sister.GetComponent<Reunion>();
    }

    public void Update()
    {
        if (slenderManAI.chaseProbability >= 1.5f)
        {
            slenderManAI.chaseProbability = 0f;
            Sister.active = true;
        }
    }
}
