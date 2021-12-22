using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    SceneFader fader;
    List<Orb> orbs;
    Door lockDoor;

    float gameTime;
    bool gameIsOver;

    public int orbNum;
    public int deathNum;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        orbs = new List<Orb>();

        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (gameIsOver)
            return;
        gameTime += Time.deltaTime;
        UIManager.UpdateTimeUI(gameTime);
    }

    public static void RegisterDoor(Door door)
    {
        instance.lockDoor = door;
    }

    public static void RegisterSceneFader(SceneFader obj)
    {
        instance.fader = obj;
    }
    public static void RegisterOrb(Orb orb)
    {
        if (!instance.orbs.Contains(orb))
            instance.orbs.Add(orb);
        UIManager.UpdateOrbUI(instance.orbs.Count);
    }
    public static void PlayerGrabbedOrb(Orb orb)
    {
        if (!instance.orbs.Contains(orb))
            return;
        instance.orbs.Remove(orb);

        if (instance.orbs.Count == 0)
            instance.lockDoor.Open();
        UIManager.UpdateOrbUI(instance.orbs.Count);
    }

    public static void PlayerDied()
    {
        instance.fader.FadeOut();
        instance.deathNum += 1;
        UIManager.UpdateDeathUI(instance.deathNum);
        //角色死亡后1.5s后重置
        instance.Invoke("RestartScene", 1.5f);
    }

    public static void PlayerWon()
    {
        instance.gameIsOver = true;
        UIManager.DisplayGameOver();
        AudioManager.PlayWinAudio();
    }

    public static bool GameOver()
    {
        return instance.gameIsOver;
    }

    void RestartScene()
    {
        instance.orbs.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
