using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SolutionForCombinationLock : MonoBehaviour
{
    [SerializeField]
    public UnityEvent puzzleSolved = new UnityEvent();

    public LockBoxTurner lockBoxTurner1;
    public LockBoxTurner lockBoxTurner2;
    public LockBoxTurner lockBoxTurner3;
    public LockBoxTurner lockBoxTurner4;
    private bool hasSolved;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("AmbientBackground");       
    }

    private void Update()
    {
        if(!hasSolved)
            Solution();
    }
    public void Solution()
    {
        if (lockBoxTurner1.oneTrue == true && lockBoxTurner2.twoTrue == true && lockBoxTurner3.threeTrue == true && lockBoxTurner4.fourTrue == true)
        {
            Solve();
        }
    }

    public void Solve()
    {
        hasSolved = true;
        puzzleSolved.Invoke();
        FindObjectOfType<AudioManager>().Play("Hint");
    }
}