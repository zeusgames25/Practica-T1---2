using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeControler : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator animator;

    private const int salto = 1;
    private const int deslizar = 2;
    private const int morir = 3;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
     }

    // Update is called once per frame
    object Update()
    {
        rb.velocity = new Vector2(5,rb.velocity.y);
        animator.SetInteger("Condicion",0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetInteger("Condicion",salto);
            rb.velocity = new Vector2(5,8);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetInteger("Condicion", deslizar);
            rb.velocity = new Vector2(5, rb.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name =="Enemigo")
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetInteger("Condicion", morir);
            Debug.Log("hola");
        }


    }
}
