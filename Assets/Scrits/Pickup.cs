using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
  public int pieces;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "puzzle")
        {
            pieces = pieces + 1;
            other.gameObject.SetActive(false);
            if (pieces == 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }
        else if (pieces <= 4)
        {
            Console.WriteLine("not enuff");
        }
    }
}

