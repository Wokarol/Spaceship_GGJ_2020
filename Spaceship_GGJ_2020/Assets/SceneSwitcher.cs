using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void StartProcess()
    {
        GetComponent<Animator>().SetTrigger("Fade Out");
    }

    public void Switch()
    {
        SceneManager.LoadScene(sceneName);
    }
}
