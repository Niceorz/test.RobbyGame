using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    static UIManager instance;

    public TextMeshProUGUI orbText, timeText, deathText, gameoverText;
    public GameObject pauseMenu;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    #region 更新文字显示
    public static void UpdateOrbUI(int orbCount)
    {
        instance.orbText.text = orbCount.ToString();
    }
    public static void UpdateDeathUI(int deathCount)
    {
        instance.deathText.text = deathCount.ToString();
    }
    public static void UpdateTimeUI(float time)
    {
        int minutes = (int)(time / 60);
        float seconds = time % 60;

        instance.timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    public static void DisplayGameOver()
    {
        instance.gameoverText.enabled = true;
    }
    #endregion
    #region 游戏暂停和继续
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    #endregion
}