using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrastrarMaiz : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private Vector2 _posicionInicial;
    private bool _estarArrastrando = false;
    public ChickenCom ChickenBh; 

    public void OnBeginDrag(PointerEventData eventData)
    {
        EmpezarArrastre();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        TerminarArrastre();
    }


    public void OnDrag(PointerEventData eventData)
    {
        if(_estarArrastrando)
        {
            this.transform.position = new Vector2(eventData.pointerCurrentRaycast.worldPosition.x, eventData.pointerCurrentRaycast.worldPosition.y);
        }
    }

    public void TerminarArrastre()
    {
        if(_estarArrastrando)
        {
            if (!this.GetComponent<Maiz>().estaEnZonaGallina)
            {
                //Debug.Log("YA llego el maizzz!!!");

                ChickenBh.BarChange();


            }

            RetornarMaizPosicion();
        }
        _estarArrastrando = false;
    }

    public void EmpezarArrastre()
    {
        _estarArrastrando = true;
        _posicionInicial = this.transform.position;

    }
    public void RetornarMaizPosicion()
    {
        this.transform.position = _posicionInicial;
    }
}
