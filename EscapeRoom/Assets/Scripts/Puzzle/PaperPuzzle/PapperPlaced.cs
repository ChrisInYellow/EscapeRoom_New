﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapperPlaced : MonoBehaviour
{
    public void PapperIsPlaced ()
    {
        if (GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().Play();
    }
}
