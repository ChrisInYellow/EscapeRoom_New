using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileDrawerAnimation : MonoBehaviour {

    //Keeps track of the drawers animator.
    public Animator drawerAnimation;

    //Sets the initial values of the animator.
	void Start () {
        drawerAnimation = gameObject.GetComponent<Animator>();
	}

    //Plays animation when called.
    public void FileAnimation()
    {
        if (!drawerAnimation.GetBool("Open"))
        {
            drawerAnimation.SetBool("Open", true);
        }
        else
        {
            drawerAnimation.SetBool("Open", false); 
        }
    }
}
