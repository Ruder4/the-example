using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public int pieces;
    public AudioClip PickupPiece;

    [Header("Torch Stuff")]
    public Light playerLantern;
    public int timeInSeconds;
    public float torchRange;

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
        } else if (other.gameObject.tag == "torch")
        {
            StopCoroutine(torchTime());
            StartCoroutine(torchTime());
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator torchTime()
    {
        float defaultRange = playerLantern.range;
        playerLantern.range = torchRange;
		yield return new WaitForSeconds(5);
        playerLantern.range = defaultRange;
    }
}

