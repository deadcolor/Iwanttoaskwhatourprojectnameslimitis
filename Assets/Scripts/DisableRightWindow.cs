using UnityEngine;
using System.Collections;

public class DisableRightWindow : MonoBehaviour {
    public GameObject MoldingTap;
    public GameObject StoreTap;

	// Use this for initialization
	void Awake () {
        turnToMoldingTap();
	}
	
	public void turnToStoreTap () {
        MoldingTap.SetActive(false);
        StoreTap.SetActive(true);
	}

    public void turnToMoldingTap()
    {
        StoreTap.SetActive(false);
        MoldingTap.SetActive(true);
    }
}
