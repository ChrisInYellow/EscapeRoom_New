using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PreasurePlate : MonoBehaviour
{
    public float minWeight = 20;
    public GameObject weightMeasurment;
    public MeshRenderer meshRenderer; 

    public UnityEvent enoughWeight = new UnityEvent();

    private float currentWeight = 0;
    private Vector3 measurementStartPos;
    private Vector3 pointerPosition;
    private Vector3 pointerCurrent;
    private float pointerAdder;

    private void Start()
    {
        measurementStartPos = weightMeasurment.transform.position;
        meshRenderer = weightMeasurment.GetComponent<MeshRenderer>();
        meshRenderer.material.SetColor("_EmissionColor", Color.red);
    }

    public void OnTriggerEnter(Collider other)
    {
        ScaleChange(other.gameObject, true);
    }

    public void OnTriggerExit(Collider other)
    {
        ScaleChange(other.gameObject, false);
    }

    private void ScaleChange(GameObject other, bool add)
    {
        if (other.GetComponent<ItemProperties>() == true)
        {
            if(add)
                currentWeight += other.GetComponent<ItemProperties>().weight;
            else
                currentWeight -= other.GetComponent<ItemProperties>().weight;
            CheckWeight();
            SmoothMeasurePosition();
            FindObjectOfType<AudioManager>().Play("Scale");
        }
    }

    public void CheckWeight ()
    {
        if (currentWeight > 20)
            currentWeight = 20;
        if (currentWeight >= minWeight)
        {
            enoughWeight.Invoke();
            FindObjectOfType<AudioManager>().Play("Hint");
        }
        if (currentWeight < 10)
            meshRenderer.material.SetColor("_EmissionColor", Color.red);

        if (currentWeight >= 10)
            meshRenderer.material.SetColor("_EmissionColor", Color.yellow);

        if (currentWeight >= 20)
            meshRenderer.material.SetColor("_EmissionColor", Color.green);
    }

    private void SmoothMeasurePosition()
    {
        pointerAdder = (weightMeasurment.transform.position.z - (measurementStartPos.z - currentWeight / 100f)) /10;
        if (pointerAdder > -0.0005 && pointerAdder < 0.0005)
            return;
        StartCoroutine(MovePointer());
    }

    private IEnumerator MovePointer()
    {
        yield return new WaitForEndOfFrame();
        weightMeasurment.transform.position -= new Vector3(0, 0, pointerAdder);
        SmoothMeasurePosition();
    }
}
