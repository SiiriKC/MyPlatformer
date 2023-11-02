using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;


public class Health : MonoBehaviour
{
    public TMP_Text HealthText;

    private int _health = 100;
    private int _maxHealth = 100;

    private SpriteRenderer _sprite;

    void Start()
    {
        DisplayHealth();
        _sprite = GetComponent<SpriteRenderer>();
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

        if(_health <= 0)
        {
            Destroy(gameObject);
        }
        DisplayHealth();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Life"))
        {
            Destroy(collider2D.gameObject);
            _health += Mathf.Min(_maxHealth, _health);
            DisplayHealth();
        }
    }


    void Update()
    {
        
    }
}
