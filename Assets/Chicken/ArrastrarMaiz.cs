using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrastrarMaiz : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private Vector2 _posicionInicial;
    private bool _estarArrastrando = false;
    public ChickenCom ChickenBh;
    public ChickenCom ChickenBh2;
    public ChickenCom ChickenBh3;
    public ChickenCom ChickenBh4;
    public ChickenCom ChickenBh5;
    public ChickenCom ChickenBh6;

    public string tagNa1 = "gall1";
    public string tagNa2 = "gall2";
    public string tagNa3 = "gall3";
    public string tagNa4 = "gall4";
    public string tagNa5 = "gall5";
    public string tagNa6 = "gall6";

    private bool gall1 = false;
    private bool gall2 = false;
    private bool gall3 = false;
    private bool gall4 = false;
    private bool gall5 = false;
    private bool gall6 = false;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagNa1))
        {
            //Debug.Log("Gallinas1 ");
            gall1 = true;
        }
        if (other.CompareTag(tagNa2))
        {
            //Debug.Log("Gallinas2 ");
            gall2 = true;
        }
        if (other.CompareTag(tagNa3))
        {
            //Debug.Log("Gallinas3 ");
            gall3 = true;
        }
        if (other.CompareTag(tagNa4))
        {
            //Debug.Log("Gallinas4 ");
            gall4 = true;
        }
        if (other.CompareTag(tagNa5))
        {
            //Debug.Log("Gallinas5 ");
            gall5 = true;
        }
        if (other.CompareTag(tagNa6))
        {
            //Debug.Log("Gallinas6 ");
            gall6 = true;
        }
    }
    public void TerminarArrastre()
    {
        if(_estarArrastrando)
        {
            if (!this.GetComponent<Maiz>().estaEnZonaGallina)
            {


                //Debug.Log("YA llego el maizzz!!!");

                if (gall1)
                {
                    gall1 = false;
                    ChickenBh.BarChange();

                }
                if (gall2)
                {
                    gall2 = false;
                    ChickenBh2.BarChange();

                }
                if (gall3)
                {
                    gall3 = false;
                    ChickenBh3.BarChange();

                }
                if (gall4)
                {
                    gall4 = false;
                    ChickenBh4.BarChange();

                }
                if (gall5)
                {
                    gall5 = false;
                    ChickenBh5.BarChange();

                }
                if (gall6)
                {
                    gall6 = false;
                    ChickenBh6.BarChange();

                }



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
