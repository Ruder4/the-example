using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TopleftAnimation : MonoBehaviour
{
    public GameObject FifthPiece;
    public GameObject FourthPiece;
    public GameObject ThirdPiece;
    public GameObject SecondPiece;
    public GameObject FirstPiece;
    Pickup pickup;
    public GameObject ThirdPersonPlayer;
 
    void Awake()
    {
        pickup = ThirdPersonPlayer.GetComponent<Pickup>();
    }


    void Update()
    {
        if (pickup.pieces == 1)
        {
            FirstPiece.SetActive(true);
        }
        if (pickup.pieces == 2)
        {
            SecondPiece.SetActive(true);
            FirstPiece.SetActive(false);
        }
        if (pickup.pieces == 3)
        {
            ThirdPiece.SetActive(true);
            SecondPiece.SetActive(false);
        }
        if (pickup.pieces == 4)
        {
            FourthPiece.SetActive(true);
            ThirdPiece.SetActive(false);
        }
        if (pickup.pieces == 5)
        {
            FifthPiece.SetActive(true);
            FourthPiece.SetActive(false);
        }
    }
}
