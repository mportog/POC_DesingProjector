using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.InputModule.Utilities.Interactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeicleManipulation : MonoBehaviour, IHoldHandler, IFocusable
{
    public GameObject painelActions;

    private Vector3 initialPosition;
    private Transform parent;
    public GameObject orbs;
    private Vector3 initialScale;

    public void OnFocusEnter()
    {
        orbs.SetActive(true);
        transform.localScale = Vector3.one;
    }
    public void OnFocusExit()
    {
        orbs.SetActive(false);
        transform.localScale = initialScale;
    }
    void OnEnable()
    {
        initialPosition = transform.localPosition;
        parent = transform.parent;
        orbs.SetActive(false);
        initialScale = new Vector3(0.7f, 0.7f, 0.7f);
    }
    public void OnHoldCanceled(HoldEventData eventData)
    {
        transform.localPosition = initialPosition;
        transform.transform.parent.SetParent(parent);
    }

    public void OnHoldCompleted(HoldEventData eventData)
    {
        gameObject.transform.parent = null;
        gameObject.GetComponent<TwoHandManipulatable>().enabled = true;
        gameObject.transform.localScale = Vector3.one;
        // painelActions.SetActive(true);
    }

    public void OnHoldStarted(HoldEventData eventData)
    {

    }
    void Update() { }
    public void HidePainel()
    {/*
        TODO: 
        1)funções de esconder painel
        2)funções de dados do veiculo (painel de texto)
        
        3)voltar veiculo para escolher outro : 
        transform.localPosition = initialPosition;
        transform.transform.parent.SetParent(parent);
             
         */
    }
}
