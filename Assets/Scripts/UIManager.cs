using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager obj;

    public Text livesLbl;
    public Text scoreLbl;
    public Transform UIPanel;

    private void Awake()
    {
        obj = this;
    }

    public void UpdateLives()
    {
        livesLbl.text = "" + Player.obj.lives;
    }

    public void UpdateScore()
    {
        scoreLbl.text = "" + Game.obj.score;
    }

    public void StartGame()
    {
        AudioManager.obj.PlayGui();
        Game.obj.gamePaused = true;
        UIPanel.gameObject.SetActive(true);
    }

    public void HideInitPanel()
    {
        AudioManager.obj.PlayGui();
        Game.obj.gamePaused = false;
        UIPanel.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        obj = null;
    }
}
