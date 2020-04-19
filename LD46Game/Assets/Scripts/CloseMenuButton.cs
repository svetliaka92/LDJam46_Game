using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenuButton : MenuButton
{
    [SerializeField] private int menuId = 2;

    public override void Click()
    {
        base.Click();

        if (Main.Instance)
            Main.Instance.CloseMenu(menuId);
    }
}
