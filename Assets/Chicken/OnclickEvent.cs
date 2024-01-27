using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnclickEvent : MonoBehaviour
{
    // Start is called before the first frame update

    private int contador = 0;

    public void OnMouseDown()
    {
        contador++;
        Debug.Log("Contador: " + contador);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
