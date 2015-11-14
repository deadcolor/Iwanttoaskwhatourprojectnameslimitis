using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class timerhandler : MonoBehaviour {
    public Image timerbar;
    GameObject a;
    changescore controlscore;
    // Use this for initialization
	void Start () {
        timerbar.fillAmount = 0;
        a = GameObject.Find("SCORENUMBER");
        controlscore = a.GetComponent<changescore>();
    }
	
	// Update is called once per frame
	void Update () {
        timerbar.fillAmount += Time.deltaTime/10;
        controlscore.increasescore(1);
        if (timerbar.fillAmount == 1)
        {
            print("Game Over");
            Application.LoadLevel(3);
            this.enabled = false;
        }
	}
}
