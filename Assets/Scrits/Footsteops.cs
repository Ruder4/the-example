using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    ThirdPersonMovement thirdPersonMovement;
    public AudioSource footstepsSound, sprintSound;

    private void Awake()
    {
        thirdPersonMovement = GameObject.Find("ThirdPersonPlayer").GetComponent<ThirdPersonMovement>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (thirdPersonMovement.speed >= 50)
            {
                footstepsSound.enabled = false;
                sprintSound.enabled = true;
            }
            else
            {
                footstepsSound.enabled = true;
                sprintSound.enabled = false;
            }
        }
        else
        {
            footstepsSound.enabled = false;
            sprintSound.enabled = false;
        }
    }
}