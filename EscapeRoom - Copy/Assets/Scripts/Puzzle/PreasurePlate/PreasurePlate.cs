using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PreasurePlate : MonoBehaviour
{
    public float maxWeight;
    public float minWeight;

    public UnityEvent enoughWeight = new UnityEvent();
    public UnityEvent notRightAmountOfWeight = new UnityEvent();

    private float currentWeight = 0;
    private bool hasBeenOpened = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ItemProperties>() == true)
        {
            currentWeight += other.gameObject.GetComponent<ItemProperties>().weight;
            CheckWeight();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ItemProperties>() == true)
        {
            currentWeight -= other.gameObject.GetComponent<ItemProperties>().weight;
            CheckWeight();
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
}
