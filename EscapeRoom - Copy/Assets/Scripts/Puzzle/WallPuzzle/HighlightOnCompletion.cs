using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnCompletion : MonoBehaviour 
{
    public int endOrder;
    private Color startColor;
    public GameObject light;

    public float timeBetween = 0.15f;
    MeshRenderer meshRenderer;
    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        startColor = meshRenderer.material.color;
    }

    public void Highlight ()
    {
        Invoke("HighlightEffect", endOrder * timeBetween );
    }

    public void HighlightEffect ()
    {
        GameObject lighting;
        lighting = Instantiate(light, transform.position, transform.rotation);
        Destroy(lighting, 1f);
        meshRenderer.material.color = new Color(255,255,255);
        Invoke("StopHighlight", 1f);
    }

    public void StopHighlight ()
    {
        meshRenderer.material.color = startColor;
    }
}
