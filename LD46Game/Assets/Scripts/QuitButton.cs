using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MenuButton
{
    public override void Click()
    {
        base.Click();

        if (Main.Instance)
            Main.Instance.QuitGame();
    }
}
