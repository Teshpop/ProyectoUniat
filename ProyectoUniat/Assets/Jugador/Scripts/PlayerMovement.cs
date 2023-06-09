using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameManager Manager;
    //Movimiento
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool crouchHeld= false, underPlataform =false;
    [SerializeField] private Rigidbody2D rbb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private BoxCollider2D bxCollider;
    //Combate
    public Transform attackP;
    public float attackR;
    public LayerMask enemyLayer;
    //Salud
    public Image hBar;
    public float hAct;
    public float hMax = 100;

    void Start()
    {
        //Salud
        hAct = hMax;
    }
    private void Update()
    {
        //Mov
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump")&& IsGrounded() && !crouchHeld &&!underPlataform)
        {
            rbb.velocity = new Vector2(rbb.velocity.x, jumpingPower);
        }
        crouchHeld = (IsGrounded() && Input.GetButton("Crouch")) ? true : false;
        if (Input.GetButtonUp("Jump") && rbb.velocity.y > 0f)
        {
            rbb.velocity = new Vector2(rbb.velocity.x, rbb.velocity.y * 0.5f);
        }
        //Combate
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        //Salud
        if (hAct<=0)
        {
            rbb.bodyType = RigidbodyType2D.Static;
            Manager.GetComponent<GameManager>().RestartLvl();
        }
    }
    //Mov
    private void FixedUpdate()
    {
        rbb.velocity = new Vector2(horizontal * speed, rbb.velocity.y);
        bxCollider.isTrigger = (crouchHeld || underPlataform) ? true : false;
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0)
            underPlataform = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0)
            underPlataform = false;
    }
    //Combate
    void Attack()
    {
        Debug.Log("Ataque");
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackP.position, attackR, enemyLayer);
        foreach (Collider2D enemy in hitEnemy)
        {
            //Debug c/enemigos
            Debug.Log("Golpeamos a" + enemy.name);
            if (enemy.CompareTag("EnemyD"))
            {
                enemy.GetComponent<Enemigo>().TakeDmg(10);
            }
            if (enemy.CompareTag("EnemyM"))
            {
                enemy.GetComponent<Enemigo2D>().TakeDmg(10);
            }
        }
    }
    private void OnDrawGizmosSelected() //Debug
    {
        if (attackP == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackP.position, attackR);
    }
    //Salud
    void TakeDmg(float a)
    {
        hAct -= a;
        hBar.fillAmount = hAct / hMax;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDmg(10);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Sword")
        {
            TakeDmg(20);
            Destroy(other.gameObject);
        }
    }
    
}
