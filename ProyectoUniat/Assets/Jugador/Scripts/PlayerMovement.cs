using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameManager Manager;
    //Movimiento
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 23f;
    private bool isFacingRight = true;
    public bool crouchHeld = false, underPlataform = false;
    private GameObject plataformaAct;
    [SerializeField] private Rigidbody2D rbb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public BoxCollider2D bxCollider;
    [SerializeField] public CircleCollider2D cirCollider;
    //dash
    private bool canDash = true;
    private bool isDashing;
    private float dashPower = 24f;
    private float dashTime = 0.2f;
    private float dashCoolDown = 1f;
    [SerializeField] public TrailRenderer tr;

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
        //prevenir mas dasheos
        if (isDashing == true) { return; }
        //Mov
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded() && !crouchHeld && !underPlataform)
        {
            rbb.velocity = new Vector2(rbb.velocity.x, jumpingPower);
        }
        crouchHeld = (IsGrounded() && Input.GetButton("Crouch")) ? true : false;
        if (Input.GetButtonUp("Jump") && rbb.velocity.y > 0f)
        {
            rbb.velocity = new Vector2(rbb.velocity.x, rbb.velocity.y * 0.5f);
        }
        if (Input.GetButton("Crouch") && IsGrounded())
        {
            if (plataformaAct != null)
            {
                StartCoroutine(noColision());
            }
        }
        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            StartCoroutine(Dash());
        }
        //Combate
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        //Salud
        if (hAct <= 0)
        {
            rbb.bodyType = RigidbodyType2D.Static;
            Manager.GetComponent<GameManager>().RestartLvl();
        }
        Flip();
    }
    //Mov
    private void FixedUpdate()
    {
        //prevenir mas dasheos
        if (isDashing == true) { return; }
        rbb.velocity = new Vector2(horizontal * speed, rbb.velocity.y);
        bxCollider.isTrigger = (crouchHeld || underPlataform) ? true : false;
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;

            //Error al disparar
            /*Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;*/

            //Sin error
            transform.Rotate(0f, 180f, 0f);
        }
    }
    public bool IsGrounded()
    {
        //Debug.Log(Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer));
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0) { }
            //underPlataform = true;
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
            if (enemy.CompareTag("Boss"))
            {
                enemy.GetComponent<BossHealth>().TakeDamage(25);
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
    public void TakeDmg(float a)
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
        //Debug.Log(other.GetComponent<HitEnemigo2D>().enemigo.atacando);
        //Debug.Log(other.name);
        /*if (other.gameObject.tag == "Sword" && other.GetComponent<HitEnemigo2D>().enemigo.atacando)
        {
            TakeDmg(10);
            
            //Destroy(other.gameObject);
        }*/
    }
    //plataformas
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Plataforma"))
        {
            plataformaAct = coll.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Plataforma"))
        {
            plataformaAct = null;
        }
    }
    private IEnumerator noColision()
    {
        TilemapCollider2D plataformaCol = plataformaAct.GetComponent<TilemapCollider2D>();
        Physics2D.IgnoreCollision(bxCollider, plataformaCol);
        Physics2D.IgnoreCollision(cirCollider, plataformaCol);
        //bxCollider.isTrigger= true;
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(bxCollider, plataformaCol, false);
        Physics2D.IgnoreCollision(cirCollider, plataformaCol, false);
        //bxCollider.isTrigger= false;
    }

    //Dash coorutina
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rbb.gravityScale;
        rbb.gravityScale = 0f;
        rbb.velocity = new Vector2(horizontal * dashPower, 0f);//horizontal*speed por que no hay fliping
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rbb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
}
