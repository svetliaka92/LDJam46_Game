using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameActualButton : MenuButton
{
    [SerializeField] private string sceneName = "Game";

    public override void Click()
    {
        base.Click();

        if (Main.Instance)
            Main.Instance.LoadScene(sceneName);
    }
}
