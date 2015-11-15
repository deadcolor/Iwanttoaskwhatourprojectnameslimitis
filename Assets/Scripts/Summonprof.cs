using UnityEngine;
using System.Collections;

public class Summonprof : MonoBehaviour {

    public GameObject proffesor;
    public GameObject proffesorSaid;
    public GameObject[] prof;
    public int profnum;
    public GameObject bal;

    void Start() {
        profnum = -1;
        StartCoroutine(profshokan());
    }

    // Update is called once per frame
    void Update()
    {
        if (profnum > 0)
            bal.GetComponentInChildren<UnityEngine.UI.Text>().text = wanted(prof[2].GetComponent<prof>().breadType, prof[2].GetComponent<prof>().breadNum);
        else if(profnum == 0)
            bal.GetComponentInChildren<UnityEngine.UI.Text>().text = " ";
        if(profnum >= 0)
            prof[2].GetComponent<prof>().isActive = true;
        if(profnum == 2)
            prof[1].transform.SetSiblingIndex(prof[2].transform.GetSiblingIndex() - 1);
        else if(profnum == 3)
        {
            prof[1].transform.SetSiblingIndex(prof[2].transform.GetSiblingIndex() - 1);
            prof[0].transform.SetSiblingIndex(prof[1].transform.GetSiblingIndex() - 1);
        }
    }

    IEnumerator profshokan()
    {
        prof = new GameObject[3];
        yield return new WaitForSeconds(Random.Range(5, 10));

        profnum = 0;

        bal = GameObject.Instantiate(proffesorSaid);
        bal.transform.SetParent(GameObject.Find("profLocation").transform);
        bal.transform.localPosition = new Vector3(-160.0f, 140.0f, 1.0f);
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
                prof[1].transform.localPosition = new Vector3(6.0f, (-40.0f), 1.1f);
                prof[1].transform.localScale = new Vector3(2.0f, 2.4f, 0.1f);
                prof[1].transform.SetSiblingIndex(prof[2].transform.GetSiblingIndex() - 1);
            }
            else if (profnum == 2)
            {
                prof[0] = GameObject.Instantiate(proffesor);
                prof[0].transform.SetParent(GameObject.Find("profLocation").transform);
                prof[0].transform.localPosition = new Vector3(9.0f, (-20.0f), 0.1f);
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
}
