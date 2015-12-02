using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changescore : MonoBehaviour
{
    public static int score;
    public int difficulty;
    Text text;

    // Use this for initialization
    void Start()
    {
        score = 0;
        text = GetComponent<Text>();
        text.text = "" + score;
    }
    public void increasescore(int number)
    {
        score += number;
        text.text = "" + score;
    }

    public void getPoint()
    {
        increasescore(20 + difficulty * 10);
    }
}