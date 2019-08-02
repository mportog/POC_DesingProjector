using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ttisit : MonoBehaviour, IInputClickHandler
{
    bool isHidden;
    public GameObject[] menus;
    public void OnInputClicked(InputClickedEventData eventData)
    {//ativa ou desativa : cor e volante
        isHidden = !isHidden;
        foreach (GameObject item in menus)
            item.SetActive(!isHidden);
        eventData.Use();
    }
    void Start() { }
    void Update()
    {//faz .T. girar
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}
