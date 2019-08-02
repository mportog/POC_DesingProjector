using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.InputModule.Utilities.Interactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSelectionBehaviour : MonoBehaviour, IFocusable, IHoldHandler, IInputClickHandler
{
    #region variables

    public GameObject cursor;
    public GameObject carro; //veiculo que pode ser escolhido
    public GameObject caixas;//caixa de vidro do veiculo
    public int numeroCaixa; //caixa esquerda = 0 / direita = 1

    private Vector3 initialPosition;
    private bool olhando;
    private bool segurando;

    #endregion

    #region Mono
    void OnEnable()
    {
        initialPosition = carro.transform.position;
        olhando = false;
        caixas.SetActive(false);
    }
    void Update()
    {
        //caso queira fazer o carro dentro da caixa girar : 
        if (olhando)
            carro.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        if (segurando)
            carro.transform.position = cursor.transform.position;
    }
    #endregion
    #region Inplementação de Interfaces
    public void OnHoldCanceled(HoldEventData eventData)
    {
        //soltou o carro pequeno fora da caixa : instancia um carro grande   
        segurando = false;
    }
    public void OnHoldCompleted(HoldEventData eventData)
    {
        //soltou dentro da caixa, não abre carro nenhum : cancelar operação
    }

    public void OnHoldStarted(HoldEventData eventData)
    {
        segurando = true;
    }
    public void OnFocusEnter()
    {
        //gira volante em direção da caixa escolhida e clareia caixa de vidro
        olhando = true;
        caixas.SetActive(true);
    }
    public void OnFocusExit()
    {
        //volta volante e escurece caixa de vidro
        olhando = false;
        caixas.SetActive(false);
    }
    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (!segurando)
        {
            var go = Instantiate(carro, null);
            go.transform.position = cursor.transform.position;
            go.GetComponent<TwoHandManipulatable>().enabled = true;
            carro.transform.localPosition = initialPosition;
        }
    }

    #endregion
}
