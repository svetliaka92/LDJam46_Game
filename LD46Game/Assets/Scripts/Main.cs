using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    private static Main _instance;
    public static Main Instance => _instance;

    [SerializeField] private Fader fader;
    [SerializeField] private float fadeInTime = 1f;
    [SerializeField] private float fadeOutTime = 1f;

    [SerializeField] private List<GameObject> menus;

    [SerializeField] private string gameSceneName = "Game";
    [SerializeField] private string loseSceneName = "LoseScreen";
    [SerializeField] private string winSceneName = "WinScreen";

    [SerializeField] private int inGameInstructionsMenuId = 2;

    string sceneToLoad;

    private bool isInGame = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _instance = this;

        DontDestroyOnLoad(gameObject);

        fader.onFadeInCompleteEvent += OnFadeIn;
        SceneManager.sceneLoaded += OnSceneLoaded;

        OpenMenu(0);
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    private void Update()
    {
        if (isInGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menus[inGameInstructionsMenuId].activeSelf)
                    CloseMenu(inGameInstructionsMenuId);
                else
                    OpenMenu(inGameInstructionsMenuId);
            }
        }
    }

    public void OpenMenu(int menuId)
    {
        if (menuId < menus.Count)
        {
            foreach (GameObject menu in menus)
                if (menu.activeSelf)
                    menu.SetActive(false);

            menus[menuId].SetActive(true);
        }
    }

    public void CloseAllMenus()
    {
        foreach (GameObject menu in menus)
            menu.SetActive(false);
    }

    public void CloseMenu(int menuId)
    {
        if (menuId < menus.Count)
            menus[menuId].SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        sceneToLoad = sceneName;

        fader.Fade(true, fadeInTime);
    }

    private void OnFadeIn()
    {
        SceneManager.LoadSceneAsync(sceneToLoad);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        fader.Fade(false, fadeOutTime);

        isInGame = scene.name.Equals(gameSceneName);
        if (isInGame)
            CloseAllMenus();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnGameWon()
    {
        // load win screen
        LoadScene(winSceneName);
    }

    public void OnGameLost()
    {
        // load lose screen
        LoadScene(loseSceneName);
    }
}
