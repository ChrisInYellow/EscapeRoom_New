using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PreasurePlate : MonoBehaviour
{
    public GameObject medicinDoor;

    public float minWeight = 20;
    public GameObject weightMeasurment;
    private MeshRenderer meshRenderer; 

    public UnityEvent enoughWeight = new UnityEvent();

    [HideInInspector]
    public float currentWeight = 0;
    private Vector3 measurementStartPos;
    private float pointerAdder;

    private static PreasurePlate instance;
    public static PreasurePlate GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        measurementStartPos = weightMeasurment.transform.position;
        meshRenderer = weightMeasurment.GetComponent<MeshRenderer>();
        meshRenderer.material.SetColor("_EmissionColor", Color.red);
    }

    public void OnCollisionEnter(Collision other)
    {
        ScaleChange(other.gameObject, true);
    }

    public void OnCollisionExit(Collision other)
    {
        ScaleChange(other.gameObject, false);
    }

    public void ScaleChange(GameObject other, bool add)
    {
        if (other.GetComponent<ItemProperties>() == true)
        {
            if (GetComponent<AudioSource>() != null)
                GetComponent<AudioSource>().Play();
            if (add)
                currentWeight += other.GetComponent<ItemProperties>().weight;
            else
                currentWeight -= other.GetComponent<ItemProperties>().weight;
            CheckWeight();
            SmoothMeasurePosition();
            
        }
    }

    public void CheckWeight ()
    {
        if (currentWeight < 0)
        {
            currentWeight = 0;
        }
        if (currentWeight >= minWeight)
        {
            enoughWeight.Invoke();
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
        if (currentWeight > 20)
            pointerAdder = (weightMeasurment.transform.position.z - (measurementStartPos.z - 20 / 100f)) / 10;

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
