using UnityEngine;
using System.Collections;

public class lifeSystem : MonoBehaviour {

	public int maxLife;

	public int life;

	public GameObject lifeCell;

	public Sprite empty;
	public Sprite filled;

	// Use this for initialization
	void Start () {
		//life = maxLife;
		for (int i = 0; i < life; ++i)
		{
			GameObject tmp = GameObject.Instantiate(lifeCell);
			tmp.transform.SetParent(GameObject.Find("LifeIndicator").transform);
			tmp.transform.localPosition = new Vector3(i * 50.0f, 0.0f, 0.0f);
			tmp.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
		for (int i = life; i < maxLife; ++i)
		{
			GameObject tmp = GameObject.Instantiate(lifeCell);
            tmp.transform.SetParent(GameObject.Find("LifeIndicator").transform);
            tmp.transform.localPosition = new Vector3(i * 50.0f, 0.0f, 0.0f);
			tmp.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tmp.GetComponent<UnityEngine.UI.Image>().sprite = empty;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void lifeDecrease()
	{
        --life;
        GameObject lifeBar = GameObject.Find("LifeIndicator");
        GameObject cell = lifeBar.transform.GetChild(life).gameObject;

        cell.GetComponent<UnityEngine.UI.Image>().sprite = empty;
        if (life == 0)
        {
            // dead
            GameObject.Find("SceneManager").GetComponent<changeScene>().goToScoreScene();
        }
	}
}
