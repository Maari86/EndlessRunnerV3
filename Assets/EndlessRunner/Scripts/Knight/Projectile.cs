using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    public static event Action HitEnemy = delegate { }; 
    [SerializeField] public float projectilespeed;
    private float direction;
    private bool hit;
    private float lifetime;
    
    

    private Animator anim;
    private BoxCollider2D coll;
    private Rigidbody2D rb;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = projectilespeed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        hit = true;
        coll.enabled = false;

        if (anim != null)
            anim.SetTrigger("KnightExplode"); //When the Object is fireball explode it
  
        else
            gameObject.SetActive(false); //When this hits anyobject deactivate 


        if (collision.tag == "Enemy")
        {
           
            collision.GetComponent<EnemyHealth>().TakeDamage(1);
            HitEnemy();
        }


    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        coll.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

   

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
