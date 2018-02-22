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

    public UnityEvent enoughWeight = new UnityEvent();
    public UnityEvent notRightAmountOfWeight = new UnityEvent();

    private float currentWeight = 0;
    private int numberOfItemsOn = 0;
    private bool hasBeenOpened = false;
    private Vector3 measurementStartPos;
    private float pointerPosition;
    private float pointerCurrent;
    private float pointerAdder;

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
            FindObjectOfType<AudioManager>().Play("Scale");
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ItemProperties>() == true)
        {
            currentWeight -= other.gameObject.GetComponent<ItemProperties>().weight;
            CheckWeight();
            MeasurementPosition();
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
    }

    public void MeasurementPosition ()
    {
        weightMeasurment.transform.position = measurementStartPos - new Vector3(0, 0, Mathf.Clamp((0.2f / minWeight) * currentWeight, 0, .2f));
    }

    void SmoothMeasurePosition()
    {
        pointerPosition = weightMeasurment.transform.position.x - measurementStartPos.x;

        if (pointerPosition < currentWeight && pointerAdder <= 0)
            pointerAdder = (currentWeight - pointerPosition) / 10f;
        else if (pointerPosition > currentWeight && pointerAdder >= 0)
            pointerAdder = (currentWeight - pointerPosition) / 10f;
        StartCoroutine(MovePointer());

        if (pointerAdder < 0.05 && pointerAdder > -0.05)
            return;
    }

    private IEnumerator MovePointer()
    {
        yield return new WaitForEndOfFrame();
        weightMeasurment.transform.position = measurementStartPos + new Vector3(pointerAdder, 0, 0);
        if (pointerAdder > 0)
        {
            if (weightMeasurment.transform.position.x - measurementStartPos.x < currentWeight)
                StartCoroutine(MovePointer());
            else
                SmoothMeasurePosition();
        }
        else
        {
            if (weightMeasurment.transform.position.x - measurementStartPos.x > currentWeight)
                StartCoroutine(MovePointer());
            else
                SmoothMeasurePosition();
        }
    }
}
