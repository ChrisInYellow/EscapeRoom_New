using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapperPlaced : MonoBehaviour
{
    public void PapperIsPlaced ()
    {
        FindObjectOfType<AudioManager>().Play("PlacingPaper");
    }
}
