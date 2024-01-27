using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ChickenCom : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    
    public float intervaloDeTiempo = 0.4f;
    private float tiempoTranscurrido = 0f;
    public TextMesh eggsCounts;
    public int eggsA = 0;
    public int eggs = 0 ;
    public GameObject bar;
    public float porcentajeCrecimiento = 0.2f; // Ajusta este valor seg�n tus necesidades
    private bool condicionCumplida = false;
    private float valorActual = 0f;

    public GameObject granjero;
    public GameObject proyectilPrefab;
    public float tiempoDeVida = 5f;





    public Transform posicionAreaCarga;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.tag.Equals("maiz"))
            {
                //Debug.Log("Entre 3");

                
                
                eventData.pointerDrag.GetComponent<Maiz>().estaEnZonaGallina = true;
            }

        }
    }


    void Start()
    {
        
        bar.transform.localScale = new Vector3(bar.transform.localScale.x, 0f, bar.transform.localScale.z);

    }

    // Update is called once per frame
    void Update()
    {
        /*tiempoTranscurrido += Time.deltaTime;


        if (tiempoTranscurrido >= intervaloDeTiempo)
        {
            //MostrarMensaje();
            tiempoTranscurrido = 0f; // Reinicia el contador
            eggs += 1;
            ContarHuevos();
           
        }*/

       
    }
    public void ContarHuevos()
    {
       
        eggsCounts.text = eggs.ToString();
        
    }
    private void MostrarMensaje()
    {
        Debug.Log("Ya pasaron " + intervaloDeTiempo + " segundos.");
    }


    public void BarChange()
    {
        if (valorActual < 100f)
        {
            //Debug.Log("Entre 2");
            valorActual += 10f;
            changeBar();
        }
    }

    private void changeBar()
    {
        


        
        // Tu l�gica de condici�n aqu�
        // Por ejemplo, si la variable "totalBarra" representa el total de la barra,
        // y "valorActual" representa la posici�n actual de la barra, podr�as hacer algo como:
        float totalBarra = 100f; // Reemplaza con el total real de la barra
                                 //float valorActual = 50f; // Reemplaza con el valor real actual de la barra

        // Calcula el progreso como un porcentaje del totalBarra
        float progreso = valorActual / totalBarra;

        // Calcula el crecimiento basado en el porcentaje y aplica la nueva escala
        float nuevoCrecimiento = Mathf.Min(progreso, 1f); // Limita el progreso a 100%
        bar.transform.localScale = new Vector3(bar.transform.localScale.x, nuevoCrecimiento, bar.transform.localScale.z);

       
    }
    public void sumarHuevos()
    {
        if(valorActual >= 20)
        {
            eggs += 1;
            ContarHuevos();

           
            valorActual -= 20;
            if (valorActual < 0)
            {
                valorActual = 0;
            }

            changeBar();
        }
    }


    public void LanzarProyectil()
    {
        if(valorActual >= 30)
        {
            valorActual -= 30;
            if (valorActual < 0)
            {
                valorActual = 0;
            }
            changeBar();
            // Verificar si el granjero y el prefab del proyectil est�n asignados
            if (granjero != null && proyectilPrefab != null)
            {
                // Obtener la posici�n del granjero
                Vector2 posicionGranjero = granjero.transform.position;

                // Instanciar el proyectil en la posici�n actual del lanzador
                GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);

                // Obtener la direcci�n hacia el granjero
                Vector2 direccion = (posicionGranjero - (Vector2)transform.position).normalized;

                // Calcular la rotaci�n hacia la direcci�n del granjero
                float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
                Quaternion rotacion = Quaternion.AngleAxis(angulo, Vector3.forward);

                // Aplicar la rotaci�n al proyectil
                proyectil.transform.rotation = rotacion;

                // Aplicar fuerza al proyectil para lanzarlo hacia el granjero
                // Ajusta la fuerza seg�n tus necesidades
                proyectil.GetComponent<Rigidbody2D>().AddForce(direccion * 10f, ForceMode2D.Impulse);

                // Destruir el proyectil despu�s de un tiempo de vida
                Destroy(proyectil, tiempoDeVida);
            }
            else
            {
                Debug.LogWarning("Aseg�rate de asignar el granjero y el prefab del proyectil en el inspector.");
            }
        }
        
    }

}







