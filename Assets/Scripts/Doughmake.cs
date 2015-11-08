using UnityEngine;
using System.Collections;

public class Doughmake : MonoBehaviour
{
	string [] a = {"1", "2", "3", "4", "5"};
	string [] b = {"6", "7", "8", "9", "10"};
	string [] c = {"11", "12", "13", "14", "15"};
	string [] d = {"16", "17", "18", "19", "20"};
	string [][] subject_list;
	public GameObject [] ingredients;
	GameObject Ingredient;
	public Object [] ingredient_list;

	void Start ()
	{
		subject_list = new string[5][];

		for (int i = 0; i < 5; i++)
		{
			subject_list [i] = new string[2];
		}

		SelectSubject (subject_list, ingredient_list);
	}

	void Update ()
	{

	}

	public void RefreshButtonPressed()
	{
		ResetList (subject_list, ingredient_list);
	}

	// Selects 5 Different Subjects and Prints Them.
	void SelectSubject(string [][] subject_list, Object [] ingredient_list)
	{
		int i = 0;
		int department;
		int subject_order;
		string subject_name = "";
		string department_name = "";

		while(i < 5)
		{
			department = Random.Range(0, 4);
			subject_order = Random.Range (0, 5);

			switch(department)
			{
				case 0: department_name = "a";
						subject_name = a[subject_order];
						break;
				case 1: department_name = "b";
						subject_name = b[subject_order];
						break;
				case 2: department_name = "c";
						subject_name = c[subject_order];
						break;
				case 3: department_name = "d";
						subject_name = d[subject_order];
						break;
				default: break;
			}

			if(SubjectCheck (i, subject_name, subject_list))
			{
				subject_list[i][0] = department_name;
				subject_list[i][1] = subject_name;

				i++;
			}
		}

		for (i = 0; i < 5; i++)
		{
			if(subject_list[i][0] == "a")
			{
				Ingredient = ingredients[0];
			}
			else if(subject_list[i][0] == "b")
			{
				Ingredient = ingredients[1];
			}
			else if(subject_list[i][0] == "c")
			{
				Ingredient = ingredients[2];
			}
			else
			{
				Ingredient = ingredients[3];
			}

			Ingredient.GetComponent<GUIText>().text = subject_list[i][1];
			Vector3 Position = new Vector3(600, (300 - (50 * i)), 0);
			Quaternion Rotation = Quaternion.Euler (new Vector3(0, 0, 0));

			ingredient_list[i] = Instantiate(Ingredient, Position, Rotation);
		}
	}

	// If the Player Clicks "Refresh" Button, Resets the Subject List.
	public void ResetList (string [][] subject_list, Object [] ingredient_list)
	{
		for (int i = 0; i < 5; i++)
		{
			Destroy (ingredient_list[i]);
		}

		for (int i = 0; i < 5; i++)
		{
			subject_list[i][0] = "";
			subject_list[i][1] = "";
		}

		SelectSubject (subject_list, ingredient_list);
	}

	/* If the Player Selects More Than 2 Subjects then Clicks
	 * "Confirm" Button, Chooses Appopriate Type of GongdaeBbang.
	 * If the Player Selects 0 or 1 Subject(s) then Clicks
	 * "Confirm" Button, Nothing Happens." */
	void ConfirmList (Object [] ingredient_list)
	{
		int selectedcount = 0;
		int select;
		Object [] selectedlist = new Object[5];
		bool allsamesubject = true;
		int gongdaebbangType;

		for (int i = 0; i < 5; i++)
		{
			select = Random.Range (0, 2);
			
			if(select == 1)
			{
				selectedlist[selectedcount] = ingredient_list[i];
				selectedcount++;
			}
		}

		if ((selectedcount == 0) || (selectedcount == 1))
		{
			return;
		}

		for(int i = 0; i < (selectedcount - 1); i++)
		{
			for(int j = (i + 1); j < selectedcount; j++)
			{
				if(selectedlist[i] == selectedlist[j])
				{
					allsamesubject = false;
				}
			}
		}

		if (allsamesubject == false)
		{
			gongdaebbangType = 0;
		}
		else
		{
			gongdaebbangType = 1;
		}
	}

	// Checks If the New Subject is the Same as Selected Subject(s).
	bool SubjectCheck(int count, string subject_name, string [][] subject_list)
	{
		bool same_subject = true;

		for (int i = 0; i < count; i++)
		{
			if(subject_name == subject_list[i][1])
			{
				same_subject = false;
			}
		}

		return same_subject;
	}
}
