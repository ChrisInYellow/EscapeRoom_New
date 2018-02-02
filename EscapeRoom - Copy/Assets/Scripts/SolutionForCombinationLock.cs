﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SolutionForCombinationLock : MonoBehaviour
{
    [SerializeField]
    public UnityEvent[] puzzleSolved = new UnityEvent[2];

    public int[] password;
    private bool[] locks = new bool[4];

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("AmbientBackground");
    }

    private void Update()
    {
        Solution();
    }

    public void SpinnerOne(int code)
    {
        print("Spinner 1"); 
        if(code == password[0])
        {
            locks[0] = true;
        }
        else
            locks[0] = false;
    }
    public void SpinnerTwo(int code)
    {
        if (code == password[1])
        {
            locks[1] = true;
        }
        else
            locks[1] = false;
    }

    public void SpinnerThree(int code)
    {
        if (code == password[2])
        {
            locks[2] = true;
        }
        else
            locks[2] = false;
    }
    public void SpinnerFour(int code)
    {
        if (code == password[3])
        {
            locks[3] = true;
        }
        else
            locks[3] = false;
    }
    public void Solution()
    {
        if (locks[0] && locks[1]&& locks[2] && locks[3])
        {
            Solve();
        }
    }

    public void Solve()
    {
        puzzleSolved[0].Invoke();
        puzzleSolved[1].Invoke();
        FindObjectOfType<AudioManager>().Play("SolutionSound");
    }
}