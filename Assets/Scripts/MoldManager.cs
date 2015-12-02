using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoldManager : MonoBehaviour {

	int selected;
	public Sprite[] breadimage;
    public GameObject fishbreads;
    public GameObject[] molds;

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
            bool isStoreTap = false;
            if (GameObject.Find("StoreTapButton").GetComponent<DisableRightWindow>().isMold == false)
                isStoreTap = true;

            if (isStoreTap)
                GameObject.Find("StoreTapButton").GetComponent<DisableRightWindow>().turnToMoldingTap();

            GameObject.Find("Put Button").GetComponent<UnityEngine.UI.Button>().interactable = false;

            if (isStoreTap)
                GameObject.Find("StoreTapButton").GetComponent<DisableRightWindow>().turnToStoreTap();
		}
		else
		{
			if (this.isSelected())
				this.transform.GetChild(selected).FindChild("CheckCircle").GetComponent<UnityEngine.UI.Image>().enabled = false;
			selected = index;
			this.transform.GetChild(index).FindChild("CheckCircle").GetComponent<UnityEngine.UI.Image>().enabled = true;

            //Chk if Now on Store tap
            bool isStoreTap=false;
            if (GameObject.Find("StoreTapButton").GetComponent<DisableRightWindow>().isMold == false)
                isStoreTap = true; 
            
            if(isStoreTap)
                GameObject.Find("StoreTapButton").GetComponent<DisableRightWindow>().turnToMoldingTap();

            GameObject.Find("Put Button").GetComponent<UnityEngine.UI.Button>().interactable = true;

            if(isStoreTap)
                GameObject.Find("StoreTapButton").GetComponent<DisableRightWindow>().turnToStoreTap();
        }
	}

	public bool isSelected()
	{
		return (selected != -1);
	}

	public int GetSelected()
	{
		return selected;
	}

	public void SetSelected(int newselect)
	{
		selected = newselect;
	}

	public void BreadHarvest(GameObject Bread)
	{
		if (this.isSelected ())
		{
			this.transform.GetChild (selected).FindChild ("CheckCircle").GetComponent<UnityEngine.UI.Image> ().enabled = false;
		}

        for (int i = 0; i < 6; i++)
		{
			if(this.transform.GetChild(i).childCount == 2)
			{
				if (Bread.transform.parent.name == molds[i].name)
				{
					selected = i;
					break;
				}
			}
		}

        for (int i = 0; i < 10; i++)
		{
			if (Bread.GetComponent<Image> ().sprite == breadimage [i])
			{
				bool isMoldingTap = false;

				if (GameObject.Find("StoreTapButton").GetComponent<DisableRightWindow>().isMold == true)
				{
					isMoldingTap = true; 
				}
				
				if(isMoldingTap)
				{
					GameObject.Find("StoreTapButton").GetComponent<DisableRightWindow>().turnToStoreTap();
				}

				switch(i)
				{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:	GameObject.Find ("StoreTap").transform.FindChild("FishBreads").GetComponent<checkFishbread>().incTotUncooked ();
							break;
					case 5:	GameObject.Find ("StoreTap").transform.FindChild("FishBreads").GetComponent<checkFishbread>().incTotBurned ();
							break;
					case 6:	GameObject.Find ("StoreTap").transform.FindChild("FishBreads").GetComponent<checkFishbread>().incTotCHEM ();
							break;
					case 7:	GameObject.Find ("StoreTap").transform.FindChild("FishBreads").GetComponent<checkFishbread>().incTotEE ();
							break;
					case 8:	GameObject.Find ("StoreTap").transform.FindChild("FishBreads").GetComponent<checkFishbread>().incTotCSE ();
							break;
					case 9:	GameObject.Find ("StoreTap").transform.FindChild("FishBreads").GetComponent<checkFishbread>().incTotCITE ();
							break;
					default: break;
				}
				
				if(isMoldingTap)
				{
					GameObject.Find("StoreTapButton").GetComponent<DisableRightWindow>().turnToMoldingTap();
				}

				break;
			}

		}

        bool isStoreTap = false;
        if (GameObject.Find("StoreTapButton").GetComponent<DisableRightWindow>().isMold == false)
            isStoreTap = true;

        if (isStoreTap)
            GameObject.Find("StoreTapButton").GetComponent<DisableRightWindow>().turnToMoldingTap();

        GameObject.Find("Put Button").GetComponent<UnityEngine.UI.Button>().interactable = false;

        if (isStoreTap)
            GameObject.Find("StoreTapButton").GetComponent<DisableRightWindow>().turnToStoreTap();

        molds[selected].GetComponent<Button>().interactable = true;
        Destroy(Bread);
        selected = -1;
	}
}
