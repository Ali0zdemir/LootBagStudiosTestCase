using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveInput;
    private Animator playerAnimator;
    public float speed;
    private Rigidbody2D rb;
    [SerializeField] private Animator bulletAnimator;
    [SerializeField] private GameObject bulletSpawnPoint;
    private bool isGrounded = true;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        if(this.transform.position.x < -8.19f )
        {
            transform.position = new Vector2(-8.19f, transform.position.y);
        }
        else if(this.transform.position.x > 8.5f)
        {
            transform.position = new Vector2(8.5f, transform.position.y);
        }
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        if (moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
        else if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0); 
        } 
        playerAnimator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !bulletAnimator.GetBool("Shoot"))
        {
            FireBullet();
            bulletAnimator.SetBool("Shoot", true);
        }

        print("isGrounded: " + isGrounded);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && playerAnimator.GetBool("Jump") == false){
            rb.AddForce(new Vector2(0, 450), ForceMode2D.Impulse);
            playerAnimator.SetBool("Jump", true);
        }
        else if(isGrounded){
            playerAnimator.SetBool("Jump", false);
        }


    }

    private void FireBullet()
    {
        GameObject bullet = BulletPooling.instance.GetPooledBullet();
        if(bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
        StartCoroutine(ShootCooldown());
    }

    private System.Collections.IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(1f);
        bulletAnimator.SetBool("Shoot", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


}
