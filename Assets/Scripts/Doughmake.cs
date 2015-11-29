using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Doughmake : MonoBehaviour
{
	string [] CHEM = {"유기화학", "물리화학", "무기화학", "화학분석", "고분자화학", "화학반응실험", "합성실험"};
	string [] EE = {"회로이론", "기초전자실험", "신호및시스템", "디지털시스템설계", "물리전자", "전자회로", "반도체전자공학"};
	string [] CE = {"프로그래밍과문제해결", "객체지향프로그래밍", "데이터구조", "운영체제", "컴퓨터구조", "프로그래밍언어", "알고리즘"};
	string [] CITE = {"창의IT설계", "인문기술융합개론", "생체의료공학", "자료구조및알고리즘", "인사조직론", "디시마프", "창업론"};
	string [][] subject_list;
	public GameObject [] ingredients;
	public GameObject [] ingredient_list;
	public Object [] chosen_list;
	public GameObject [] gongdaebbangs;
	GameObject Ingredient;
    int selectednum;
    public int difficulty;

	void Start ()
	{
		selectednum = 0;
		subject_list = new string[5][];

		for (int i = 0; i < 5; i++)
		{
			subject_list [i] = new string[2];
		}

		SelectSubject ();
	}

	void Update ()
	{

	}

	// Activated When Refresh Button is Pressed.
	public void RefreshButtonPressed()
	{
		for (int i = 0; i < 5; i++)
		{
			chosen_list[i] = null;
		}

		selectednum = 0;
		ResetList ();
	}

	// Activated When "Make" Button is Pressed.
	public void MakeButtonPressed()
	{
		ConfirmList ();
	}

	// Selects 5 Different Subjects and Prints Them.
	void SelectSubject()
	{
		int i = 0;
		int department;
		int subject_order;
		string subject_name = "";
		string department_name = "";

		while(i < 5)
		{
			if(ingredient_list[i] != null)
			{
				i++;
				continue;
			}

			while(true)
			{
				department = Random.Range(0, 4);
				subject_order = Random.Range (0, 7);

				switch(department)
				{
					case 0: department_name = "CHEM";
							subject_name = CHEM[subject_order];
							break;
					case 1: department_name = "EE";
							subject_name = EE[subject_order];
							break;
					case 2: department_name = "CE";
							subject_name = CE[subject_order];
							break;
					case 3: department_name = "CITE";
							subject_name = CITE[subject_order];
							break;
					default: break;
				}

				if(SubjectCheck (subject_name))
				{
					subject_list[i][0] = department_name;
					subject_list[i][1] = subject_name;
					break;
				}
				else
				{
					continue;
				}
			}
		
			if(subject_list[i][0] == "CHEM")
			{
				Ingredient = Instantiate (ingredients[0]);
			}
			else if(subject_list[i][0] == "EE")
			{
				Ingredient = Instantiate (ingredients[1]);
			}
			else if(subject_list[i][0] == "CE")
			{
				Ingredient = Instantiate (ingredients[2]);
			}
			else if(subject_list[i][0] == "CITE")
			{
				Ingredient = Instantiate (ingredients[3]);
			}
			                                                                   
			Ingredient.transform.SetParent(GameObject.Find ("Ingredients List").transform);
			Ingredient.GetComponentInChildren<Text>().text = subject_list[i][1];
			Ingredient.transform.localPosition = new Vector3(0, (130 - (50 * i)), 0);
			Ingredient.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

			ingredient_list[i] = Ingredient;
			UnityEditor.Events.UnityEventTools.AddObjectPersistentListener<GameObject>(ingredient_list[i].GetComponent<Toggle>().onValueChanged, IngredientSelected, ingredient_list[i]);
			
			i++;
		}

		Ingredient = null;
	}

	// If the Player Clicks "Refresh" Button, Resets the Subject List.
	public void ResetList ()
	{
		for (int i = 0; i < 5; i++)
		{
			Destroy (ingredient_list[i]);
			ingredient_list[i] = null;
		}

		for (int i = 0; i < 5; i++)
		{
			subject_list[i][0] = "";
			subject_list[i][1] = "";
		}

		SelectSubject ();
	}
	
	// Activated When Subject Object Button is Pressed.
	public void IngredientSelected (GameObject ingredient)
	{
		int index = 0;

		for (int i = 0; i < 5; i++)
		{
			if(ingredient == ingredient_list[i])
			{
				index = i;
				break;
			}
		}

		if (ingredient.GetComponent<Toggle>().isOn == true)
		{
			ColorBlock temp = ingredient.GetComponent<Toggle>().colors;
			temp.normalColor = ingredient.GetComponent<Toggle>().colors.pressedColor;
			temp.highlightedColor = ingredient.GetComponent<Toggle>().colors.pressedColor;
			temp.pressedColor = ingredient.GetComponent<Toggle>().colors.normalColor;

			ingredient.GetComponent<Toggle>().colors = temp;

			SelectIngredient (index);
		}
		else
		{
			ColorBlock temp = ingredient.GetComponent<Toggle>().colors;
			temp.normalColor = ingredient.GetComponent<Toggle>().colors.pressedColor;
			temp.highlightedColor = ingredient.GetComponent<Toggle>().colors.pressedColor;
			temp.pressedColor = ingredient.GetComponent<Toggle>().colors.normalColor;

			ingredient.GetComponent<Toggle>().colors = temp;

			CancelIngredient (index);
		}
	}

	// Selects Chosen Ingredient If that Ingredient is not Selected.
	void SelectIngredient(int index)
	{
		if (selectednum == 5)
		{
			return;
		}

		chosen_list [index] = ingredient_list [index];

		selectednum++;
	}

	// Cancels Selection of Chosen Ingredient If that Ingredient is Already Selected.
	void CancelIngredient(int index)
	{
		if (selectednum == 0)
		{
			return;
		}

		chosen_list [index] = null;

		selectednum--;
	}

	/* If the Player Selects More Than 2 Subjects then Clicks
	 * "Confirm" Button, Chooses Appopriate Type of GongdaeBbang.
	 * If the Player Selects 0 or 1 Subject(s) then Clicks
	 * "Confirm" Button, Nothing Happens." */
	void ConfirmList ()
	{
		bool allsamesubject = true;
		int gongdaebbangtype;
		string subject = "";

		if (selectednum < 2)
		{
			for(int i = 0; i < 4; i++)
			{
				ingredient_list[i].GetComponent<Toggle>().isOn = false;
				chosen_list[i] = null;
			}

			selectednum = 0;

			return;
		}

		for (int i = 0; i < 4; i++)
		{
			if (chosen_list [i] == null)
			{
				continue;
			}

			for (int j = (i + 1); j < 5; j++)
			{
				if (chosen_list [j] == null)
				{
					continue;
				}
				else
				{
					if(subject_list[i][0] != subject_list[j][0])
					{
						allsamesubject = false;
						break;
					}
					else
					{
						subject = subject_list[i][0];
					}
				}
			}

			if(allsamesubject == false)
			{
				break;
			}
		}

		for (int i = 0; i < 5; i++)
		{
			if(chosen_list[i] != null)
			{
				Destroy (chosen_list[i]);
				chosen_list[i] = null;
				ingredient_list[i] = null;

				subject_list[i][0] = "";
				subject_list[i][1] = "";
			}
		}

		if (allsamesubject == false)
		{
			gongdaebbangtype = 0;
		}
		else
		{
			if(subject == "CHEM")
			{
				gongdaebbangtype = 1;
			}
			else if(subject == "EE")
			{
				gongdaebbangtype = 2;
			}
			else if(subject == "CE")
			{
				gongdaebbangtype = 3;
			}
			else
			{
				gongdaebbangtype = 4;
			}
		}

        GameObject gongdaebbang = GameObject.Instantiate(gongdaebbangs[gongdaebbangtype]);
        gongdaebbang.GetComponent<fishBread>().setDifficulty(difficulty);

		int moldindex = GameObject.Find ("MoldManager").GetComponent<MoldManager> ().GetSelected();
		GameObject mold = null;

		switch (moldindex)
		{
			case 0:
				gongdaebbang.transform.SetParent (GameObject.Find ("Mold").transform);
				mold = GameObject.Find ("Mold");
				break;
			case 1:
				gongdaebbang.transform.SetParent (GameObject.Find ("Mold (1)").transform);
				mold = GameObject.Find ("Mold (1)");
				break;
			case 2:
				gongdaebbang.transform.SetParent (GameObject.Find ("Mold (2)").transform);
				mold = GameObject.Find ("Mold (2)");
				break;
			case 3:
				gongdaebbang.transform.SetParent (GameObject.Find ("Mold (3)").transform);
				mold = GameObject.Find ("Mold (3)");	
				break;
			case 4:
				gongdaebbang.transform.SetParent (GameObject.Find ("Mold (4)").transform);
				mold = GameObject.Find ("Mold (4)");
				break;
			case 5:
				gongdaebbang.transform.SetParent (GameObject.Find ("Mold (5)").transform);
				mold = GameObject.Find ("Mold (5)");
				break;
			default:
				break;
		}

		mold.transform.FindChild ("CheckCircle").GetComponentInChildren<Image>().enabled = false;
		mold.GetComponent<Button>().interactable = false;

		GameObject.Find ("MoldManager").GetComponent<MoldManager> ().SetSelected (-1);
		GameObject.Find("Put Button").GetComponent<UnityEngine.UI.Button>().interactable = false;

		gongdaebbang.transform.localPosition = new Vector3 (0, 0, 0);
		gongdaebbang.transform.localScale = new Vector3(1, 1, 1);
		
		selectednum = 0;

		SelectSubject ();
	}

	// Checks If the New Subject is the Same as Selected Subject(s).
	bool SubjectCheck(string subject_name)
	{
		bool subject_check = true;

		for (int i = 0; i < 4; i++)
		{
			if(subject_list[i][1] == "")
			{
				continue;
			}

			if(subject_name == subject_list[i][1])
			{
				subject_check = false;
			}
		}

		return subject_check;
	}
}
