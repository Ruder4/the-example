using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public int pieces;

    [Header("Puzzle Piece UI Update")]
    public GameObject puzzlePieceUI;

    [Header("Torch Test Stuff")]
	public Light playerLantern;
	public int torchRange = 500;
    public int torchBurnoutTime = 20;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "puzzle")
        {
            pieces = pieces + 1;
            ChangePuzzleUI(pieces);
            other.gameObject.SetActive(false);
            if (pieces == 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            } else
			{
                Debug.Log("Not enough.");
			}
        } else if (other.gameObject.tag == "torch")
        {
            StopCoroutine(torchTimer()); // This makes sure the timer for the torch resets if you pick up two before the first one runs out.
            StartCoroutine(torchTimer()); 
            Destroy(other.gameObject); // Destroy the torch object (so you can't pick it up again oooo scary)
        }
    }

    IEnumerator torchTimer()
    {
		playerLantern.range = torchRange; // Uses the players already-built-in lantern and just increases the range
		yield return new WaitForSeconds(torchBurnoutTime); // Wait twenty seconds
        playerLantern.range = 100; // Resets range back to normal.
    }

    void ChangePuzzleUI(int pieceNumber)
	{
        Sprite puzzleSprite = Resources.Load<Sprite>($"pp{pieceNumber} ss");
        RuntimeAnimatorController puzzleController = Resources.Load<RuntimeAnimatorController>($"pp{pieceNumber} ss_0");

        Image puzzleImage = puzzlePieceUI.GetComponent<Image>();
        Animator puzzleAnimator = puzzlePieceUI.GetComponent<Animator>();

        puzzleImage.sprite = puzzleSprite;
        puzzleImage.preserveAspect = true;
        puzzleAnimator.runtimeAnimatorController = puzzleController;
	}
}

