using UnityEngine;
using System.Collections;

public class Summonprof : MonoBehaviour {

    public GameObject proffesor;
    public GameObject proffesorSaid;
    public GameObject[] prof;
    public int profnum;
    public GameObject bal;

    public Sprite[] imgs = new Sprite[17];

    void Start() {
        profnum = -1;
        StartCoroutine(profshokan());
    }

    // Update is called once per frame
    void Update()
    {
        if (profnum > 0)
            bal.GetComponentInChildren<UnityEngine.UI.Text>().text = wanted(prof[2].GetComponent<prof>().breadType, prof[2].GetComponent<prof>().breadNum);
        else if (profnum == 0)
            bal.GetComponentInChildren<UnityEngine.UI.Text>().text = " ";
        if (profnum > 0)
            prof[2].GetComponent<prof>().isActive = true;
        if(profnum == 1)
        {
            prof[2].GetComponent<UnityEngine.UI.Image>().color = new Color(prof[2].GetComponent<UnityEngine.UI.Image>().color.r, prof[2].GetComponent<UnityEngine.UI.Image>().color.g, prof[2].GetComponent<UnityEngine.UI.Image>().color.b, 1f);
        }
        else if (profnum == 2)
        { 
            prof[1].transform.SetSiblingIndex(prof[2].transform.GetSiblingIndex() - 1);
            prof[2].GetComponent<UnityEngine.UI.Image>().color = new Color(prof[2].GetComponent<UnityEngine.UI.Image>().color.r, prof[2].GetComponent<UnityEngine.UI.Image>().color.g, prof[2].GetComponent<UnityEngine.UI.Image>().color.b, 1f);
            prof[1].GetComponent<UnityEngine.UI.Image>().color = new Color(prof[1].GetComponent<UnityEngine.UI.Image>().color.r, prof[1].GetComponent<UnityEngine.UI.Image>().color.g, prof[1].GetComponent<UnityEngine.UI.Image>().color.b, 0.6f);
        }
        else if(profnum == 3)
        {
            prof[1].transform.SetSiblingIndex(prof[2].transform.GetSiblingIndex() - 1);
            prof[0].transform.SetSiblingIndex(prof[1].transform.GetSiblingIndex() - 1);
            prof[2].GetComponent<UnityEngine.UI.Image>().color = new Color(prof[2].GetComponent<UnityEngine.UI.Image>().color.r, prof[2].GetComponent<UnityEngine.UI.Image>().color.g, prof[2].GetComponent<UnityEngine.UI.Image>().color.b, 1f);
            prof[1].GetComponent<UnityEngine.UI.Image>().color = new Color(prof[1].GetComponent<UnityEngine.UI.Image>().color.r, prof[1].GetComponent<UnityEngine.UI.Image>().color.g, prof[1].GetComponent<UnityEngine.UI.Image>().color.b, 0.6f);
            prof[0].GetComponent<UnityEngine.UI.Image>().color = new Color(prof[0].GetComponent<UnityEngine.UI.Image>().color.r, prof[0].GetComponent<UnityEngine.UI.Image>().color.g, prof[0].GetComponent<UnityEngine.UI.Image>().color.b, 0.3f);
        }
    }

    IEnumerator profshokan()
    {
        prof = new GameObject[3];
        yield return new WaitForSeconds(Random.Range(5, 10));

        profnum = 0;

        bal = GameObject.Instantiate(proffesorSaid);
        bal.transform.SetParent(GameObject.Find("profLocation").transform);
        bal.transform.localPosition = new Vector3(-160.0f, 120.0f, 1.0f);
        bal.transform.localScale = new Vector3(1.8f, 1.8f, 1.0f);

        for (int i = 0; i < 50; i++)
        {
            if (profnum == 0)
            {
                prof[2] = GameObject.Instantiate(proffesor);
                prof[2].transform.SetParent(GameObject.Find("profLocation").transform);
                prof[2].transform.localPosition = new Vector3(3.0f, (-60.0f), 2.1f);
                prof[2].transform.localScale = new Vector3(2.0f, 2.4f, 0.1f);
            }
            else if (profnum == 1)
            {
                prof[1] = GameObject.Instantiate(proffesor);
                prof[1].transform.SetParent(GameObject.Find("profLocation").transform);
                prof[1].transform.localPosition = new Vector3(6.0f, (0.0f), 1.1f);
                prof[1].transform.localScale = new Vector3(2.0f, 2.4f, 0.1f);
                prof[1].transform.SetSiblingIndex(prof[2].transform.GetSiblingIndex() - 1);
            }
            else if (profnum == 2)
            {
                prof[0] = GameObject.Instantiate(proffesor);
                prof[0].transform.SetParent(GameObject.Find("profLocation").transform);
                prof[0].transform.localPosition = new Vector3(9.0f, (60.0f), 0.1f);
                prof[0].transform.localScale = new Vector3(2.0f, 2.4f, 0.1f);
                prof[1].transform.SetSiblingIndex(prof[2].transform.GetSiblingIndex() - 1);
                prof[0].transform.SetSiblingIndex(prof[1].transform.GetSiblingIndex() - 1);
            }
            if (profnum < 3)
                profnum++;

            yield return new WaitForSeconds(Random.Range(6, 11));
        }
    }

    public string wanted(int type, int num)
    {
        switch (type)
        {
            case 0:
                return "컴공과빵" + num + "개 주세요";
            case 1:
                return "창공과빵" + num + "개 주세요";
            case 2:
                return "전자과빵" + num + "개 주세요";
            case 3:
                return "화학과빵" + num + "개 주세요";
            case 4:
                return "아무거나 주세요";
        }
        return "Error";
    }
    public void receiveFishBread(int numUncooked, int numBurned, int numCITE, int numCSE, int numCHEM, int numEE)
    {
        int breadType = prof[2].GetComponent<prof>().breadType;
        int breadNum = prof[2].GetComponent<prof>().breadNum;
        switch (breadType)
        {
            case 0:
                if (numCSE == breadNum && numUncooked == 0 && numBurned == 0 && numCITE == 0 && numCHEM == 0 && numEE == 0)
                    GameObject.Find("SCORENUMBER").GetComponent<changescore>().increasescore(100);
                else
                    GameObject.Find("LifeSystemObject").GetComponent<lifeSystem>().lifeDecrease();
                break;
            case 1:
                if (numCITE == breadNum && numUncooked == 0 && numBurned == 0 && numCSE == 0 && numCHEM == 0 && numEE == 0)
                    GameObject.Find("SCORENUMBER").GetComponent<changescore>().increasescore(100);
                else
                    GameObject.Find("LifeSystemObject").GetComponent<lifeSystem>().lifeDecrease();
                break;
            case 2:
                if (numEE == breadNum && numUncooked == 0 && numBurned == 0 && numCSE == 0 && numCHEM == 0 && numCITE == 0)
                    GameObject.Find("SCORENUMBER").GetComponent<changescore>().increasescore(100);
                else
                    GameObject.Find("LifeSystemObject").GetComponent<lifeSystem>().lifeDecrease();
                break;
            case 3:
                if (numCHEM == breadNum && numUncooked == 0 && numBurned == 0 && numCSE == 0 && numEE == 0 && numCITE == 0)
                    GameObject.Find("SCORENUMBER").GetComponent<changescore>().increasescore(100);
                else
                    GameObject.Find("LifeSystemObject").GetComponent<lifeSystem>().lifeDecrease();
                break;
            case 4:
                if (numBurned != 0 || numUncooked != 0)
                    GameObject.Find("SCORENUMBER").GetComponent<changescore>().increasescore(100);
                else
                    GameObject.Find("LifeSystemObject").GetComponent<lifeSystem>().lifeDecrease();
                break;
        }
        prof[2].GetComponent<prof>().breadType = 4;
        prof[2].GetComponent<prof>().goHome();
    }
}
