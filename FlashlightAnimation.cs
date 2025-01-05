using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightAnimation : MonoBehaviour
{
    public Animator flashanim;

    private void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))  
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                flashanim.ResetTrigger("Walk");
                flashanim.SetTrigger("Sprint");
            }
            else
            {
                flashanim.ResetTrigger("Sprint");
                flashanim.SetTrigger("Walk");
            }
        }
    }
}
