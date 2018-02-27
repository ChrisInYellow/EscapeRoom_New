using UnityEngine;

public class MedicineDoorOpen : MonoBehaviour 
{
    private float rotateAngle = 100;
    private float duration = 2f;
    private bool open = false;

    public void Update()
    {
        if (open)
        {
            Open();
        }
    }

    public void ActivateBool ()
    {
        open = true;
    }

    public void Open ()
    {
        if (GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().Play();
        transform.Rotate(Vector3.down, rotateAngle * Time.deltaTime * (1 / duration));
        Invoke("DisableScript", duration);
    }

    public void DisableScript ()
    {
        GetComponent<MedicineDoorOpen>().enabled = false;
    }
}
