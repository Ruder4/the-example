using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
  public int pieces;
    public AudioClip PickupPiece;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "puzzle")
        {
            AudioSource.PlayClipAtPoint(PickupPiece, transform.position);
            pieces = pieces + 1;
            other.gameObject.SetActive(false);
            if (pieces == 5)
            {
                SceneManager.LoadScene("Game Win");
            }
        }
        else if (pieces <= 4)
        {
            Console.WriteLine("not enuff");
        }
    }
}

