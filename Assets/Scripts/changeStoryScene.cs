using UnityEngine;
using System.Collections;

public class changeStoryScene : MonoBehaviour {

	public Sprite[] Scenes;
	public int CurrentScene = 0;

	public void gotoNext(){
		if (CurrentScene == 3)
			Application.LoadLevel (2);
		else {
			GameObject.Find ("storyImage").GetComponent<UnityEngine.UI.Image> ().sprite = Scenes [CurrentScene + 1];
			CurrentScene++;
		}
	}

	public void gotoPrev(){
		if (CurrentScene == 0)
			Application.LoadLevel (0);
		else {
			GameObject.Find ("storyImage").GetComponent<UnityEngine.UI.Image> ().sprite = Scenes [CurrentScene - 1];
			CurrentScene--;
		}
	}
}
