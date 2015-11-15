using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class finalscore : MonoBehaviour {
    int score;
    Text text;
	// Use this for initialization
	void Start () {
        score = changescore.score;
        text = GetComponent<Text>();
        text.text = "" + score;
	}
}
