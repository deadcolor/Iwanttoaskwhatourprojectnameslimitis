using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisableRightWindow : MonoBehaviour {
    public GameObject MoldingTap;
    public GameObject StoreTap;
    public bool isMold;

	// Use this for initialization
	void Awake () {
		MoldingTap.SetActive(false);
		StoreTap.SetActive(true);
		isMold = false;

		GameObject.Find ("StoreTap").transform.FindChild ("FishBreads").GetComponent<checkFishbread> ().initializeNumber ();
        
		StoreTap.SetActive(false);
		MoldingTap.SetActive(true);
		isMold = true;
	}
	
	public void turnToStoreTap () {
        MoldingTap.SetActive(false);
        StoreTap.SetActive(true);
        isMold = false;

		ColorBlock temp1 = GameObject.Find("StoreTapButton").GetComponent<Button>().colors;
		temp1.normalColor = GameObject.Find("StoreTapButton").GetComponent<Button>().colors.pressedColor;
		temp1.highlightedColor = GameObject.Find("StoreTapButton").GetComponent<Button>().colors.pressedColor;
		temp1.pressedColor = GameObject.Find("StoreTapButton").GetComponent<Button>().colors.normalColor;
		
		GameObject.Find("StoreTapButton").GetComponent<Button>().colors = temp1;

		ColorBlock temp2 = GameObject.Find("MoldingTapButton").GetComponent<Button>().colors;
		temp2.normalColor = GameObject.Find("MoldingTapButton").GetComponent<Button>().colors.pressedColor;
		temp2.highlightedColor = GameObject.Find("MoldingTapButton").GetComponent<Button>().colors.pressedColor;
		temp2.pressedColor = GameObject.Find("MoldingTapButton").GetComponent<Button>().colors.normalColor;
		
		GameObject.Find("MoldingTapButton").GetComponent<Button>().colors = temp2;
	}

    public void turnToMoldingTap()
    {
        StoreTap.SetActive(false);
        MoldingTap.SetActive(true);
        isMold = true;

		ColorBlock temp1 = GameObject.Find("StoreTapButton").GetComponent<Button>().colors;
		temp1.normalColor = GameObject.Find("StoreTapButton").GetComponent<Button>().colors.pressedColor;
		temp1.highlightedColor = GameObject.Find("StoreTapButton").GetComponent<Button>().colors.pressedColor;
		temp1.pressedColor = GameObject.Find("StoreTapButton").GetComponent<Button>().colors.normalColor;
		
		GameObject.Find("StoreTapButton").GetComponent<Button>().colors = temp1;
		
		ColorBlock temp2 = GameObject.Find("MoldingTapButton").GetComponent<Button>().colors;
		temp2.normalColor = GameObject.Find("MoldingTapButton").GetComponent<Button>().colors.pressedColor;
		temp2.highlightedColor = GameObject.Find("MoldingTapButton").GetComponent<Button>().colors.pressedColor;
		temp2.pressedColor = GameObject.Find("MoldingTapButton").GetComponent<Button>().colors.normalColor;
		
		GameObject.Find("MoldingTapButton").GetComponent<Button>().colors = temp2;
    }
}
