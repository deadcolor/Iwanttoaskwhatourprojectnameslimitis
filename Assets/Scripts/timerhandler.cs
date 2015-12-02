using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class timerhandler : MonoBehaviour {
    public Image timerbar;
    const int totaltime=180;
	// Use this for initialization
	void Start () {
        timerbar.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timerbar.fillAmount += Time.deltaTime/totaltime;
        if (timerbar.fillAmount == 1)
        {
            print("Game Over");
            Application.LoadLevel(3);
            this.enabled = false;
        }
	}
}
