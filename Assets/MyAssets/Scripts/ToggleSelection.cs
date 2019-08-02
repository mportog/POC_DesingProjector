using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSelection : MonoBehaviour, IInputClickHandler, IFocusable
{
    private bool isOpen;

    public bool spray;
    public GameObject select;
    public GameObject tooltip;
    public GameObject[] otherMenus;//outros menus que nao o que cliquei

    public void OnInputClicked(InputClickedEventData eventData)
    {
        isOpen = !isOpen;
        select.SetActive(isOpen);
        otherMenus[0].SetActive(!isOpen);
        otherMenus[1].SetActive(!isOpen);
        if (spray && isOpen)
            GetComponentInChildren<ParticleSystem>(true).gameObject.SetActive(true);
        if (spray && !isOpen)
            GetComponentInChildren<ParticleSystem>().gameObject.SetActive(false);
    }
    void OnDisable()
    {
        select.SetActive(false);
    }
    void OnEnable()
    {         
        isOpen = false;
    }

    void Update()
    {
       
    }

    public void OnFocusEnter()
    {
        tooltip.SetActive(true);
    }

    public void OnFocusExit()
    {
        tooltip.SetActive(false);
    }
}
