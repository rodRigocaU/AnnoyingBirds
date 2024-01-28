using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

//https://www.youtube.com/watch?v=AgBtRQ9coIc
public class Controller : MonoBehaviour
{
    private BoxCollider2D bodyBox;
    private RaycastHit2D hit;
    private Vector3 movePlyr;

// public Animator animator;
    public float speed;

    //Otro video
    [SerializeField] private Transform[] pointMove;
    [SerializeField] private float minDistance;
    private int randomNumber;
    private bool pause = false;

    //Test
    private Timer timerScript;
    public float maxSpeed = 7f;
    public AudioSource audioSource;
     


    private float pauseTime = 5.30f; // Tiempo de pausa en segundos
    private float audioTimer = 0f;
    private float pauseTimer = 0f;

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


    private void Start()
    {
        bodyBox = GetComponent<BoxCollider2D>();
        randomNumber = UnityEngine.Random.Range(0, pointMove.Length);
        timerScript = FindObjectOfType<Timer>();
    }

    private void FixedUpdate()
    {
        float remainingTime = timerScript.GetTimer();
        AdjusteSpeedByTimer(remainingTime);


        if (pauseTimer > 0f)
        {
            pauseTimer -= Time.deltaTime;
            speed = 0f;
            audioSource.Play();
          


        }
        else
        {
            audioSource.Stop();

            transform.position =
            Vector2.MoveTowards(transform.position, pointMove[randomNumber].position, speed * Time.deltaTime);

            //Se ven raro los cambios de Sprites
            //animator.SetFloat("Horizontal", transform.position.x);
            //animator.SetFloat("Vertical", transform.position.y);

            //DIstancia entre el punto aleatorio y nuestro personaje es menor a la distancia minima se cambia
            if (Vector2.Distance(transform.position, pointMove[randomNumber].position) < minDistance)
            {
                randomNumber = UnityEngine.Random.Range(0, pointMove.Length);
            }
        }

       

        
    }

    private void AdjusteSpeedByTimer(float remainingTime)
    {
        // Ajustar la velocidad basada en el tiempo restante
        if (remainingTime <= 60f && remainingTime > 0f)
        {
            float normalizedTime = remainingTime / 60f;
            speed = Mathf.Lerp(0.2f, maxSpeed, 1f - normalizedTime);
            //Debug.Log("Remaining Time: " + remainingTime + ", Speed: " + speed);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PROYECTIL"))
        {
            //Debug.Log("Te golpearon con kk");
            pauseTimer = pauseTime;
            audioSource.Stop();
            audioSource.Play();
            
        }

        /*if (other.CompareTag("gall1"))
        {
            Debug.Log("Gallinas1 ");
            if(ChickenBh.eggs > 0)
                ChickenBh.eggs -= 1;
        }
        if (other.CompareTag(tagNa2))
        {
            if (ChickenBh2.eggs > 0)
                ChickenBh2.eggs -= 1;
        }
        if (other.CompareTag(tagNa3))
        {
            if (ChickenBh3.eggs > 0)
                ChickenBh3.eggs -= 1;
        }
        if (other.CompareTag(tagNa4))
        {
            if (ChickenBh4.eggs > 0)
                ChickenBh4.eggs -= 1;
        }
        if (other.CompareTag(tagNa5))
        {
            if (ChickenBh5.eggs > 0)
                ChickenBh5.eggs -= 1;
        }
        if (other.CompareTag(tagNa6))
        {
            if (ChickenBh6.eggs > 0)
                ChickenBh6.eggs -= 1;
        }*/



    }


}


/*
        // movimiento de Teclado
        // GetAxisRaw //0 o 1 si es //GetAxis [0,1]
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        movePlyr = new Vector3(hor * speed, ver * speed, 0); // x,y,z

        animator.SetFloat("Horizontal", hor);
        animator.SetFloat("Vertical", ver);
        transform.Translate(movePlyr.x, movePlyr.y, movePlyr.z);*/