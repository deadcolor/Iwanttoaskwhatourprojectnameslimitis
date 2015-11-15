using UnityEngine;
using System.Collections;

public class DisableRightWindow : MonoBehaviour {
    public GameObject MoldingTap;
    public GameObject StoreTap;
    public bool isMold;

	// Use this for initialization
	void Awake () {
        turnToMoldingTap();
        isMold = true;
	}
	
	public void turnToStoreTap () {
        MoldingTap.SetActive(false);
        StoreTap.SetActive(true);
        isMold = false;
	}

    public void turnToMoldingTap()
    {
        StoreTap.SetActive(false);
        MoldingTap.SetActive(true);
        isMold = true;
    }
}
