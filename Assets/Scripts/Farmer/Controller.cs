using System.Collections;
using System.Collections.Generic;
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

    //Test
    private Timer timerScript;
    public float maxSpeed = 7f;


    private void Start()
    {
        bodyBox = GetComponent<BoxCollider2D>();
        randomNumber = Random.Range(0, pointMove.Length);
        timerScript = FindObjectOfType<Timer>();
    }

    private void FixedUpdate()
    {
        float remainingTime = timerScript.GetTimer();
        AdjusteSpeedByTimer(remainingTime);


        transform.position =
            Vector2.MoveTowards(transform.position, pointMove[randomNumber].position, speed * Time.deltaTime);

        //Se ven raro los cambios de Sprites
        // animator.SetFloat("Horizontal", transform.position.x);
        // animator.SetFloat("Vertical", transform.position.y);

        //DIstancia entre el punto aleatorio y nuestro personaje es menor a la distancia minima se cambia
        if (Vector2.Distance(transform.position, pointMove[randomNumber].position) < minDistance)
        {
            randomNumber = Random.Range(0, pointMove.Length);
        }
    }

    private void AdjusteSpeedByTimer(float remainingTime)
    {
        // Ajustar la velocidad basada en el tiempo restante
        if (remainingTime <= 60f && remainingTime > 0f)
        {
            float normalizedTime = remainingTime / 60f;
            speed = Mathf.Lerp(1.0f, maxSpeed, 1f - normalizedTime);
            Debug.Log("Remaining Time: " + remainingTime + ", Speed: " + speed);
        }
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