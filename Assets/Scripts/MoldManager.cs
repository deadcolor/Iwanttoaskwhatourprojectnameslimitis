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
			GameObject.Find("Put Button").GetComponent<UnityEngine.UI.Button>().interactable = false;
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
        Debug.Log("Before for loop"+selected);
        for (int i = 0; i < 6; i++)
		{
			if(this.transform.GetChild(i).childCount == 2)
			{
				if(this.transform.GetChild(i).transform.GetChild (1) == Bread)
				{
					selected = i;
					break;
				}
			}
		}
        Debug.Log("After for loop" + selected);
        for (int i = 0; i < 6; i++)
		{
			if (Bread.GetComponent<Image> ().sprite == breadimage [i])
			{
				switch(i)
				{
                    case 0:
                        fishbreads.GetComponent<checkFishbread>().incTotUncooked();
                        break;
                    case 1:
                        fishbreads.GetComponent<checkFishbread>().incTotBurned();
                        break;
                    case 2:
                        fishbreads.GetComponent<checkFishbread>().incTotCHEM();
                        break;
                    case 3:
                        fishbreads.GetComponent<checkFishbread>().incTotEE();
                        break;
                    case 4:
                        fishbreads.GetComponent<checkFishbread>().incTotCSE();
                        break;
                    case 5:
                        fishbreads.GetComponent<checkFishbread>().incTotCITE();
                        break;
                    default: break;
                        /*
                        case 0: GameObject.Find ("StoreTap").transform.FindChild("FishBreads").GetComponent<checkFishbread>().incTotUncooked ();
                                break;
                        case 1: GameObject.Find ("StoreTap").transform.FindChild("FishBreads").GetComponent<checkFishbread>().incTotBurned ();
                                break;
                        case 2: GameObject.Find ("StoreTap").transform.FindChild("FishBreads").GetComponent<checkFishbread>().incTotCHEM ();
                                break;
                        case 3: GameObject.Find ("StoreTap").transform.FindChild("FishBreads").GetComponent<checkFishbread>().incTotEE ();
                                break;
                        case 4: GameObject.Find ("StoreTap").transform.FindChild("FishBreads").GetComponent<checkFishbread>().incTotCSE ();
                                break;
                        case 5: GameObject.Find ("StoreTap").transform.FindChild("FishBreads").GetComponent<checkFishbread>().incTotCITE ();
                                break;
                        default: break;
                        */
                }

				break;
			}

		}
        //this.transform.GetChild(selected).GetComponent<Button>().interactable = true;
        molds[selected].GetComponent<Button>().interactable = true;
        Destroy(Bread);
        selected = -1;
	}
}
