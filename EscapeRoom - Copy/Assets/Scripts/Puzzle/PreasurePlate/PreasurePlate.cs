using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PreasurePlate : MonoBehaviour
{
    public float maxWeight;
    public float minWeight;
    public GameObject weightMeasurment;

    public UnityEvent enoughWeight = new UnityEvent();
    public UnityEvent notRightAmountOfWeight = new UnityEvent();

    private float currentWeight = 0;
    private int numberOfItemsOn = 0;
    private bool hasBeenOpened = false;
    private Vector3 measurementStartPos;

    private void Start()
    {
        measurementStartPos = weightMeasurment.transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ItemProperties>() == true)
        {
            currentWeight += other.gameObject.GetComponent<ItemProperties>().weight;
            CheckWeight();
            MeasurementPosition();
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ItemProperties>() == true)
        {
            currentWeight -= other.gameObject.GetComponent<ItemProperties>().weight;
            CheckWeight();
            MeasurementPosition();
        }
    }

    public void CheckWeight ()
    {
        if (currentWeight <= maxWeight && currentWeight >= minWeight)
        {
            enoughWeight.Invoke();
            hasBeenOpened = true;
        }
        if ((currentWeight > maxWeight || currentWeight < minWeight) && hasBeenOpened == false)
        {
            notRightAmountOfWeight.Invoke();
        }
    }

    public void MeasurementPosition ()
    {
        weightMeasurment.transform.position = measurementStartPos - new Vector3(0, 0, Mathf.Clamp((0.2f / minWeight) * currentWeight, 0, .2f));
    }
}
