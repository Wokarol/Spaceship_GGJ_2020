using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayersShip))]
[RequireComponent(typeof(EnemyShip))]
public class GameDirector : MonoBehaviour
{
    [SerializeField] private HealthbarController playerHP;
    [SerializeField] private HealthbarController enemyHP;
    [Space]
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject win;
    [Space]
    [SerializeField] private string menuScene;

    private EnemyShip enemy = null;
    private PlayersShip player = null;

    public EnemyShip Enemy => enemy;
    public PlayersShip Player => player;

    bool ended = false;

    private void Awake()
    {
        Time.timeScale = 1;

        TryGetComponent(out player);
        TryGetComponent(out enemy);

        enemy.PlayersShip = player;
        player.EnemyShip = enemy;

        playerHP.Bind(() => player.Health);
        enemyHP.Bind(() => enemy.Health);
    }

    private void Update()
    {
        if (ended)
            return;

        if(Player.Health <= 0)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            Wokarol.Scheduler.DelayCall(() => SceneManager.LoadScene(menuScene), 2f);
            ended = true;
        }

        if (Enemy.Health <= 0)
        {
            Time.timeScale = 0;
            win.SetActive(true);
            Wokarol.Scheduler.DelayCall(() => SceneManager.LoadScene(menuScene), 2f);
            ended = true;
        }

        if (Keyboard.current.pKey.isPressed)
        {
            SceneManager.LoadScene(menuScene);
        }
    }
}
