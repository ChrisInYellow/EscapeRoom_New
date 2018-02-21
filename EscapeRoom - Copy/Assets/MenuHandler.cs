using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
using UnityEngine.EventSystems;

public class MenuHandler : MonoBehaviour 
{
    public GameObject hand01, hand02;

    public GameObject gameRoom;
    public GameObject menuRoom;

    public Button resumeGame;

    private bool menuStarted = false;

    VRTK_UIPointer pointer01;
    VRTK_UIPointer pointer11;

    VRTK_Pointer pointer02;
    VRTK_Pointer pointer22;

    VRTK_StraightPointerRenderer pointer03;
    VRTK_StraightPointerRenderer pointer33;

    private void Start()
    {
        pointer01 = hand01.GetComponent<VRTK_UIPointer>();
        pointer02 = hand01.GetComponent<VRTK_Pointer>();
        pointer03 = hand01.GetComponent<VRTK_StraightPointerRenderer>();

        pointer11 = hand02.GetComponent<VRTK_UIPointer>();
        pointer22 = hand02.GetComponent<VRTK_Pointer>();
        pointer33 = hand02.GetComponent<VRTK_StraightPointerRenderer>();
    }

    public void MenuStart ()
    {
        if (menuStarted == false)
        {
            menuStarted = true;
            PointerHandler();
            StartMenu();
            EventSystem.current.SetSelectedGameObject(resumeGame.gameObject);
        }
        else 
        {
            menuStarted = false;                         //FIX SHIT AND STUFF
            PointerHandler();
            QuitMenu();
        }
    }

    private void StartMenu ()
    {
        menuRoom.SetActive(true);
        gameRoom.SetActive(false);
    }

    private void QuitMenu ()
    {
        menuRoom.SetActive(false);
        gameRoom.SetActive(true);
    }

    public void PointerHandler ()
    {
        if (menuStarted == false)
        {
            pointer01.enabled = false;
            pointer02.enabled = false;
            pointer03.enabled = false;
            pointer11.enabled = false;
            pointer22.enabled = false;
            pointer33.enabled = false;
        }
        else
        {
            pointer01.enabled = true;
            pointer02.enabled = true;
            pointer03.enabled = true;
            pointer11.enabled = true;
            pointer22.enabled = true;
            pointer33.enabled = true;
        }
    }
}
