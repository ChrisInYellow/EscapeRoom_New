using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SolutionForCombinationLock : MonoBehaviour
{
    [SerializeField]
    public UnityEvent puzzleSolved = new UnityEvent();

    public int[] password;
    private bool[] locks = new bool[4];

    private void Start()
    {

        FindObjectOfType<AudioManager>().Play("AmbientBackground");
        
        SpinnerOne(1);
        SpinnerTwo(1);
        SpinnerThree(1);
        SpinnerFour(1);
    }

    public void SpinnerOne(int code)
    {
        if(code == password[0])
        {
            locks[0] = true;
        }
        else
            locks[0] = false;
        Solution();
    }
    public void SpinnerTwo(int code)
    {
        if (code == password[1])
        {
            locks[1] = true;
        }
        else
            locks[1] = false;
        Solution();
    }

    public void SpinnerThree(int code)
    {
        if (code == password[2])
        {
            locks[2] = true;
        }
        else
            locks[2] = false;
        Solution();
    }
    public void SpinnerFour(int code)
    {
        if (code == password[3])
        {
            locks[3] = true;
        }
        else
            locks[3] = false;
        Solution();
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
        puzzleSolved.Invoke();
        FindObjectOfType<AudioManager>().Play("DoorCreak");
    }
}