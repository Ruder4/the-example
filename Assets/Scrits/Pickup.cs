using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public int pieces;

    [Header("Torch Test Stuff")]
	public Light playerLantern;
	public int torchRange = 500;
    public int torchBurnoutTime = 20;

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
        } else if (other.gameObject.tag == "torch")
        {
            StopCoroutine(torchTimer()); // This makes sure the timer for the torch resets if you pick up two before the first one runs out.
            StartCoroutine(torchTimer()); 
            Destroy(other.gameObject); // Destroy the torch object (so you can't pick it up again oooo scary)
        }
        else if (pieces <= 4)
        {
            Console.WriteLine("not enuff");
        }
    }

    IEnumerator torchTimer()
    {
		playerLantern.range = torchRange; // Uses the players already-built-in lantern and just increases the range
		yield return new WaitForSeconds(torchBurnoutTime); // Wait twenty seconds
        playerLantern.range = 100; // Resets range back to normal.
    }
}

