using UnityEngine;

public class ItemProperties : MonoBehaviour
{
    public float weight;
    [HideInInspector]
    public bool onPreasurePlate = false;

    public void OnCollisionEnter(Collision other)
    {
        if (onPreasurePlate)
        {
            return;
        }
        
        if (other.gameObject.tag == "PreasurePlate")
        {
            WeightChange(true);
        }

        else if (other.gameObject.GetComponent<ItemProperties>() && other.gameObject.GetComponent<ItemProperties>().onPreasurePlate)
        {
            WeightChange(true);
        }
    }
    public void OnCollisionExit(Collision other)
    {
        if (!onPreasurePlate)
        {
            return;
        }

        if (other.gameObject.tag == "PreasurePlate")
        {
            WeightChange(false);
        }

        else if (other.gameObject.GetComponent<ItemProperties>() && other.gameObject.GetComponent<ItemProperties>().onPreasurePlate)
        {
            WeightChange(false);
        }
        
    }

    private void WeightChange(bool add)
    {
        onPreasurePlate = add;
        PreasurePlate.GetInstance().ScaleChange(gameObject, add);
    }
}
