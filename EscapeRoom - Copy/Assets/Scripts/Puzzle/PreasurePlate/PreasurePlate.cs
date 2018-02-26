using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PreasurePlate : MonoBehaviour
{
    public float maxWeight;
    public float minWeight;
    public GameObject weightMeasurment;
    public MeshRenderer meshRenderer; 

    public UnityEvent enoughWeight = new UnityEvent();
    public UnityEvent notRightAmountOfWeight = new UnityEvent();

    private float currentWeight = 0;
    private int numberOfItemsOn = 0;
    private bool hasBeenOpened = false;
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
        if (other.gameObject.GetComponent<ItemProperties>() == true)
        {
            currentWeight += other.gameObject.GetComponent<ItemProperties>().weight;
            CheckWeight();
            SmoothMeasurePosition();
            FindObjectOfType<AudioManager>().Play("Scale");
        }       
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ItemProperties>() == true)
        {
            currentWeight -= other.gameObject.GetComponent<ItemProperties>().weight;
            CheckWeight();
            SmoothMeasurePosition();
            FindObjectOfType<AudioManager>().Play("Scale");
        }
    }

    public void CheckWeight ()
    {
        if (currentWeight <= maxWeight && currentWeight >= minWeight)
        {
            enoughWeight.Invoke();
            hasBeenOpened = true;
            FindObjectOfType<AudioManager>().Play("Hint");
        }
        if ((currentWeight > maxWeight || currentWeight < minWeight) && hasBeenOpened == false)
        {
            notRightAmountOfWeight.Invoke();
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
        if (currentWeight > 20)
            currentWeight = 20;
        pointerPosition = measurementStartPos - new Vector3(0, 0, currentWeight / 100f);
        pointerAdder = (weightMeasurment.transform.position.z - pointerPosition.z)/10;
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
