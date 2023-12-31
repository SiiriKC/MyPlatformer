using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinCollecting : MonoBehaviour
{
    private int points = 0;
    public TMP_Text scoreText;
    public AudioSource _coinCollect;

    private void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Coin"))
        {
            Destroy(collider2D.gameObject);
            points += 10;
            UpdateScoreText();

            if(_coinCollect != null)
            {
                _coinCollect.Play();
            }
        }

    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score:" + points.ToString();
        }
    }
   
}
