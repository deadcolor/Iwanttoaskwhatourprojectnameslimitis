using UnityEngine;
using System.Collections;

public class MoldManager : MonoBehaviour {

	int selected;

	// Use this for initialization
	void Start () {
		selected = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void moldClicked(int index)
	{
		if (selected == index)
		{
			this.transform.GetChild(selected).FindChild("CheckCircle").GetComponent<UnityEngine.UI.Image>().enabled = false;
			selected = -1;
			GameObject.Find("Put Button").GetComponent<UnityEngine.UI.Button>().interactable = false;
		}
		else
		{
			if (this.isSelected())
				this.transform.GetChild(selected).FindChild("CheckCircle").GetComponent<UnityEngine.UI.Image>().enabled = false;
			selected = index;
			this.transform.GetChild(index).FindChild("CheckCircle").GetComponent<UnityEngine.UI.Image>().enabled = true;
			GameObject.Find("Put Button").GetComponent<UnityEngine.UI.Button>().interactable = true;
		}
	}

	public bool isSelected()
	{
		return (selected != -1);
	}
}
