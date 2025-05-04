using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private float health = 100f;
    private float speed = 2f;
    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // Assuming the player has the tag "Player"
        if (target == null)
        {
            Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.AddScore(50); 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(50f); 
            collision.gameObject.SetActive(false); 
        }
    }

}
