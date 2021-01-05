using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPolice : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 5f;
    private Animator anim;
    public float x , y;

    public Rigidbody rb;
    public float fuerzaSalto=8f;
    public bool puedoSaltar;

    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoGolpe=10f;

    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();


    }

    void FixedUpdate()
    {
        if(!estoyAtacando)
        {
            if(y>=-1&&y<0)
            {
                transform.Translate(x*Time.deltaTime*velocidadMovimiento,0,-y*Time.deltaTime*velocidadMovimiento);
                transform.rotation = Quaternion.Euler(0,90,0);
            }else if(y<=1&&y>0)
            {
                transform.Translate(-x*Time.deltaTime*velocidadMovimiento,0,y*Time.deltaTime*velocidadMovimiento);
                transform.rotation = Quaternion.Euler(0,-90,0);
            }else
            {
                transform.Translate(-x*Time.deltaTime*velocidadRotacion,0,0);
                transform.rotation = Quaternion.Euler(0,-90,0);
            }
        }

        

        if(avanzoSolo)
        {
            rb.velocity=transform.forward* impulsoGolpe;
        }


    }

    // Update is called once per frame
    void Update()
    {
        x=Input.GetAxis("Vertical");
        y=Input.GetAxis("Horizontal");

        if(transform.position.y<1) puedoSaltar=true;
        else puedoSaltar=false;


        if(Input.GetKeyDown(KeyCode.Return) && !estoyAtacando)
        {
            anim.SetTrigger("golpeo");
            estoyAtacando=true;
        }

        anim.SetFloat("velX",x);   
        anim.SetFloat("velY",y); 
        if(puedoSaltar)
        {
            if(!estoyAtacando)
            { 
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("salte",true);
                    rb.AddForce(new Vector3(0,fuerzaSalto,0),ForceMode.Impulse);
                }
            }
            anim.SetBool("tocoSuelo",true);
        }else
        {
            EstoyCayendo();
        }
    }

    public void EstoyCayendo()
    {
        anim.SetBool("tocoSuelo",false);
        anim.SetBool("salte",false);
    }

    public void DejeDeGolpear()
    {
        estoyAtacando=false;
    }

    public void AvanzoSolo()
    {
        avanzoSolo=true;
    }

    public void DejoDeAvanzar()
    {
        avanzoSolo=false;
    }


}
