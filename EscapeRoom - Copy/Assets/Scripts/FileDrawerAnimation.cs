using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileDrawerAnimation : MonoBehaviour {


    public Animator anim;

	void Start () {
        anim = gameObject.GetComponent<Animator>();
	}

    public void FileAnimOpen()
    {
        if (!anim.GetBool("Open"))
        {
            anim.SetBool("Open", true);
        }
        else
        {
            anim.SetBool("Open", false); 
        }
        
    }
}
