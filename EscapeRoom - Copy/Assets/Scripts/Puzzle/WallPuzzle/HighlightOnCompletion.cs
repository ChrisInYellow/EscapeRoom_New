using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnCompletion : MonoBehaviour 
{
    public int endOrder;

    public float timeBetween = 0.15f;
    MeshRenderer meshRenderer;
    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Highlight ()
    {
        Invoke("HighlightEffect", endOrder * timeBetween );
    }

    public void HighlightEffect ()
    {
        meshRenderer.material.color = new Color(0,0,0);
    }
}
