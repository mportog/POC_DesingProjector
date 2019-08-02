using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSelectionCars : MonoBehaviour, IInputClickHandler
{
    private bool isOpen;
    public GameObject selectCars;
    public void OnInputClicked(InputClickedEventData eventData)
    {
        isOpen = !isOpen;
        selectCars.SetActive(isOpen);
    }

    // Use this for initialization
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
