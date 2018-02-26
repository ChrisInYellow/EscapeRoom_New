using UnityEngine;

public class ItemProperties : MonoBehaviour
{
    public float weight;
    private bool onPreasurePlate = false;

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<ItemProperties>())
        {

        }
        if (other.gameObject.tag == "PreaurePlate")
        {

        }
    }
}
