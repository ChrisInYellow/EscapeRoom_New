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
    private int numberOfItemsOn = 0;
    private bool hasBeenOpened = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ItemProperties>() == true)
        {
            currentWeight += other.gameObject.GetComponent<ItemProperties>().weight;
            CheckWeight();
        }
        if (numberOfItemsOn < 5 && numberOfItemsOn > 0)
        {
            numberOfItemsOn += 1;
            transform.position -= new Vector3(0,0.5f,0);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ItemProperties>() == true)
        {
            currentWeight -= other.gameObject.GetComponent<ItemProperties>().weight;
            CheckWeight();
        }
        numberOfItemsOn -= 1;
        transform.position += new Vector3(0, 0.5f, 0);
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
