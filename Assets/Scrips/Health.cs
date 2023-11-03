using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public TMP_Text HealthText;
    
    public int _health = 100;
    private int _maxHealth = 100;

    private SpriteRenderer _sprite;
    public Animator _anime;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        DisplayHealth();
        _sprite = GetComponent<SpriteRenderer>();
        _anime = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    IEnumerator FlashRed()
    {
        if (_sprite != null)
        {
            _sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            _sprite.color = Color.white;
        }
    }

    void DisplayHealth()
    {
        if (HealthText != null)
        {
            HealthText.text = _health.ToString();
        }
    }

    public void Damage(int damage)
    {
        StartCoroutine(FlashRed());
        _health -= damage;
        DisplayHealth();

        if (_health <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                Die();
                Invoke("RestartLevel", 2f);
            }

            else
            {
                Destroy(gameObject);
            }
        }
        
    }

    public void Die()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _anime.SetTrigger("Death");
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Life"))
        {
            Destroy(collider2D.gameObject);
            int livesToAdd = 50;
            int livesAvailable = _maxHealth - _health;
            int livesGained = Mathf.Min(livesToAdd, livesAvailable);
            _health += livesGained;
            DisplayHealth();
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
