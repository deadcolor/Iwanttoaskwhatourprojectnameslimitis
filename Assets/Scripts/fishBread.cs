using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fishBread : MonoBehaviour {
    const int OneSideDone = 3, DoneToBurn = 5;	// 시간 재는데 사용

	float time;

	// 각 면의 상태를 표시
	public string firstSide;
	public string secondSide;

    Image bread;
    public Sprite[] sprites;    // 한쪽-뒤집은-완성-탄 순서

	// Use this for initialization
	void Start () {
		time = 0;
		firstSide = "Raw";
		secondSide = "Raw";
        bread = GetComponent<Image>();
        bread.sprite = sprites[0];
        // StartCoroutine("Bake1");
    }

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (bread.sprite == sprites[0])
			/*if (Input.GetMouseButtonDown(0)) {
				bread.sprite = sprites[2];
				time = 0;
			}
			else*/ if (time >= OneSideDone) {
				bread.sprite = sprites[1];
				firstSide = "Done";
			}

		if (bread.sprite == sprites[1])
			/*if (Input.GetMouseButtonDown(0)) {
				bread.sprite = sprites[2];
				time = 0;
			}
			else*/ if (time >= OneSideDone + DoneToBurn) {
				bread.sprite = sprites[4];
				firstSide = "Burn";
			}

		if (time >= OneSideDone && bread.sprite == sprites[2]) {
			bread.sprite = sprites[3];
			secondSide = "Done";
		}

		if (time >= OneSideDone + DoneToBurn && bread.sprite == sprites[3]) {
			bread.sprite = sprites[4];
			secondSide = "Burn";
		}
	}

	void OnMouseDown() {
		if (bread.sprite == sprites[0] || bread.sprite == sprites[1]) {
			bread.sprite = sprites[2];
			time = 0;
		}
	}
}