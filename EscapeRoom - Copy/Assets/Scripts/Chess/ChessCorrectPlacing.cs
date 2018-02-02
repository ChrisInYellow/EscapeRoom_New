using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CorrectPawnCombo : MonoBehaviour {

    private static readonly CorrectPawnCombo instance = new CorrectPawnCombo();

    static CorrectPawnCombo()
    {
    }

    private CorrectPawnCombo()
    {
    }

    public static CorrectPawnCombo Instance
    {
        get
        {
            return instance;
        }
    }
}
