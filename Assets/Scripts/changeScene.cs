using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {

    public void goTointroScene()
    {
        Application.LoadLevel(0);
    }

    public void goToGameModeSelect()
    {
        Application.LoadLevel(1);
    }

    public void goToGameScene()
    {
        Application.LoadLevel(2);
    }

    public void goToScoreScene()
    {
        Application.LoadLevel(3);
    }
}
