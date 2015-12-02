using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeImage : MonoBehaviour {

	public Sprite[] images;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeImgExplain(int number) {
		Image explainImg;
		explainImg = GetComponent<Image>();
		explainImg.sprite = images[number];

	}

}
