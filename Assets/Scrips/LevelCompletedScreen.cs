using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelCompletedScreen : MonoBehaviour
{
    public Finish finish;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Finish"))
        {
            if (gameObject.CompareTag("Player"))
            {
                finish.gameOver();
            }
        }
    }
}