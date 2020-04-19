using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MenuButton
{
    [SerializeField] private int menuToOpen = 1;

    public override void Click()
    {
        base.Click();

        if (Main.Instance)
            Main.Instance.OpenMenu(menuToOpen);
    }
}
