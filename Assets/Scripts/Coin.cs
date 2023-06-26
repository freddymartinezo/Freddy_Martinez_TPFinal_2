using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreGive = 50;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Game.obj.addScore(scoreGive);
            AudioManager.obj.PlayCoin();
            UIManager.obj.UpdateScore();
            FXManager.obj.ShowPop(transform.position);

            gameObject.SetActive(false);
        }
    }
}
