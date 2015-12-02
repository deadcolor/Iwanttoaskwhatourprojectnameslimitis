using UnityEngine;
using System.Collections;

public class BGMmanager : MonoBehaviour {
    // Use this for initialization
    public AudioSource introBGM;
    void Awake () {
        if (changeScene.BGMplayed == 0)
        {
            introBGM.Play();
        }
        changeScene.BGMplayed++;
    }
	void Start () {
        DontDestroyOnLoad(GameObject.Find("BGM"));
    }
}
