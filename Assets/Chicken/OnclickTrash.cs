using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnclickTrash : MonoBehaviour
{
    // Start is called before the first frame update
    private int contador = 0;

    public void OnMouseDown()
    {
        contador++;
        Debug.Log("Contador trash: " + contador);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
