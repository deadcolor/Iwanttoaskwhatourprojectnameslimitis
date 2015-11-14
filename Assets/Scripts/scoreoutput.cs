using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreoutput : MonoBehaviour {
    Text text;
    int scoreend=changescore.score;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = " "+scoreend;
	}
}
