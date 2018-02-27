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

    VRTK_UIPointer uiPointer01;
    VRTK_UIPointer uiPointer02;
    VRTK_Pointer pointer01;
    VRTK_Pointer pointer02;
    VRTK_StraightPointerRenderer pointerRenderer01;
    VRTK_StraightPointerRenderer pointerRenderer02;

    private void Start()
    {
        uiPointer01 = hand01.GetComponent<VRTK_UIPointer>();
        pointer01 = hand01.GetComponent<VRTK_Pointer>();
        pointerRenderer01 = hand01.GetComponent<VRTK_StraightPointerRenderer>();

        uiPointer02 = hand02.GetComponent<VRTK_UIPointer>();
        pointer02 = hand02.GetComponent<VRTK_Pointer>();
        pointerRenderer02 = hand02.GetComponent<VRTK_StraightPointerRenderer>();
    }

    public void MenuStart ()
    {
        if (menuStarted == false)
        {
            menuStarted = true;
            StartMenu();
            PointerHandler();
            EventSystem.current.SetSelectedGameObject(resumeGame.gameObject);
        }
        else 
        {
            menuStarted = false;                         //FIX SHIT AND STUFF
            QuitMenu();
            PointerHandler();
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
            uiPointer01.enabled = false;
            pointer01.enabled = false;
            pointerRenderer01.enabled = false;
            uiPointer02.enabled = false;
            pointer02.enabled = false;
            pointerRenderer02.enabled = false;
        }
        else
        {
            uiPointer01.enabled = true;
            pointer01.enabled = true;
            pointerRenderer01.enabled = true;
            uiPointer02.enabled = true;
            pointer02.enabled = true;
            pointerRenderer02.enabled = true;
        }
    }
}
