using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {
    public static int BGMplayed = 0;
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

    public void goToGameScene1()
    {
        Application.LoadLevel(4);
    }

    public void goToGameScene2()
    {
        Application.LoadLevel(5);
    }

	public void goToExplainScene()
	{
		Application.LoadLevel (6);
	}

	public void goToStoryScene()
	{
		Application.LoadLevel (7);
	}
}
