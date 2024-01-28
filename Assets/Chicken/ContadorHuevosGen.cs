using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ContadorHuevosGen : MonoBehaviour
{
    public ChickenCom ChickenBh;
    public ChickenCom ChickenBh2;
    public ChickenCom ChickenBh3;
    public ChickenCom ChickenBh4;
    public ChickenCom ChickenBh5;
    public ChickenCom ChickenBh6;
    public TextMesh contS;
    int cont = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        cont = ChickenBh.huevosContGe();
        cont += ChickenBh2.huevosContGe();
        cont += ChickenBh3.huevosContGe();
        cont += ChickenBh4.huevosContGe();
        cont += ChickenBh5.huevosContGe();
        cont += ChickenBh6.huevosContGe();

        contS.text = cont.ToString();



    }
}
