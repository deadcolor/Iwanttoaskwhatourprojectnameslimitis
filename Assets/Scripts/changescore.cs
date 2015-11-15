using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changescore : MonoBehaviour {
    public static int score;
    Text text;

	// Use this for initialization
	void Start () {
        score = 0;
        text = GetComponent<Text>();
        text.text = "" + score;
	}
    public void increasescore(int number)
    {
        score += number;
        text.text = "" + score;
    }
}
