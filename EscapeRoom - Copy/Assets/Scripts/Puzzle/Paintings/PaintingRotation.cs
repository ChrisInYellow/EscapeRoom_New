using UnityEngine;

public class PaintingRotation : MonoBehaviour 
{
    //private bool cooldown = false;
    private bool isRotating = false;
    private bool correctPos = false;
    private int currentRotationPos = 0;

    public int startPos;
    public float rotateAngle = 45f;
    public float duration = .5f;
    public int numberOfPainting;


    private InteractivePainting paintingController;

    public void Start()
    {
        paintingController = InteractivePainting.GetInstance();
        currentRotationPos = startPos;
        transform.Rotate(Vector3.back, (rotateAngle * startPos));
    }

    public void FixedUpdate () 
	{
        if (isRotating)
        {
            transform.Rotate(Vector3.back, rotateAngle * Time.deltaTime * (1 / duration));
        }
	}

    public void StartRotation ()
    {
        //if(!cooldown)
        if (!isRotating)
        {
            currentRotationPos += 1;
            if (currentRotationPos >= 8)
            {
                currentRotationPos = 0;
                correctPos = true;
                paintingController.CheckNumberOfCorrectPositions(correctPos, numberOfPainting);
                GetComponent<AudioSource>().Play();
            }
            else
            {
                correctPos = false;
                paintingController.CheckNumberOfCorrectPositions(correctPos, numberOfPainting);
            }
            //cooldown = true;
            isRotating = true;
            Invoke("StopRotation", duration);
        }
    }

    public void StopRotation ()
    {
        //cooldown = false;
        isRotating = false;
    }
}
