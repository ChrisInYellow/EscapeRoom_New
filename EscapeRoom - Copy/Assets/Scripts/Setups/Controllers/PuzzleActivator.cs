using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleActivator : MonoBehaviour {

    [SerializeField]
    public UnityEvent[] puzzleSolved = new UnityEvent[10];

    public void puzzle0()
    {
        puzzleSolved[0].Invoke();
    }

    public void puzzle1()
    {
        puzzleSolved[1].Invoke();
    }

    public void puzzle2()
    {
        puzzleSolved[2].Invoke();
    }

    public void puzzle3()
    {
        puzzleSolved[3].Invoke();
    }
    public void puzzle4()
    {
        puzzleSolved[4].Invoke();
    }
    public void puzzle5()
    {
        puzzleSolved[5].Invoke();
    }
    public void puzzle6()
    {
        puzzleSolved[6].Invoke();
    }
    public void puzzle7()
    {
        puzzleSolved[7].Invoke();
    }

}
