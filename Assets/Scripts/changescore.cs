using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changescore : MonoBehaviour {
    public static int score;

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        score = 0;
        text.text = " "+score;
        DontDestroyOnLoad(transform.gameObject);
    }

    public void increasescore(int number)
    {
        score += number;
        text.text = " "+score;
    }
}
