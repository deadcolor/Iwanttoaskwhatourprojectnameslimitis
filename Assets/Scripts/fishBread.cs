using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fishBread : MonoBehaviour {
	// 한쪽 면이 익는 시간, 익은 상태에서 타는 시간을 나타내는 상수들
    const int OneSideDone=8;
    int DoneToBurn;

	// 시간 재는데 사용
	float time;

	// 각 면의 상태를 표시 (Raw-Done-Burn)
	public string firstSide;
	public string secondSide;

	// 붕어빵 이미지의 sprite를 변경하는 데 사용
    Image bread;
    public Sprite[] sprites;    // 안익은것(0)-한쪽(1)-뒤집은(2)-완성(3)-탄(4) 순서

	// Use this for initialization
	void Start () {
		time = 0;
		firstSide = "Raw";
		secondSide = "Raw";
        bread = GetComponent<Image>();
        bread.sprite = sprites[0];
    }

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		// 첫번째 면 Raw->Done
		if (bread.sprite == sprites[0] && time >= OneSideDone) {
				bread.sprite = sprites[1];
				firstSide = "Done";
			}

		// 첫번째 면 Done->Burn
		if (bread.sprite == sprites[1] && time >= OneSideDone + DoneToBurn) {
				bread.sprite = sprites[4];
				firstSide = "Burn";
			}

		// 두번째 면 Raw->Done
		if (bread.sprite == sprites[2] && time >= OneSideDone) {
			bread.sprite = sprites[3];
			secondSide = "Done";
		}

		// 두번째 면 Done->Burn
		if (bread.sprite == sprites[3] && time >= OneSideDone + DoneToBurn) {
			bread.sprite = sprites[4];
			secondSide = "Burn";
		}
	}
	
	// 붕어빵의 첫번째 면을 굽는 동안 클릭될 경우 뒤집음
	public void OnClick() {
		if (bread.sprite == sprites[0] || bread.sprite == sprites[1])
		{
			if((firstSide == "Raw") || (firstSide == "Burn"))
			{
				GameObject.Find("MoldManager").GetComponent<MoldManager>().BreadHarvest(gameObject);
			}
			else if(firstSide == "Done")
			{
				if(sprites[1] == sprites[2])
				{
					GameObject.Find("MoldManager").GetComponent<MoldManager>().BreadHarvest(gameObject);
				}
				else
				{
					time = 0;
					bread.sprite = sprites[2];
				}
			}
		}
		else
		{
			GameObject.Find("MoldManager").GetComponent<MoldManager>().BreadHarvest(gameObject);
		}

	}

    public void setDifficulty(int _diff)
    {
        if (_diff == 0)
            DoneToBurn = 16;
        else if (_diff == 1)
            DoneToBurn = 14;
        else
            DoneToBurn = 12;
    }
}