using UnityEngine;
using System.Collections;

public class prof : MonoBehaviour
{
    public float Max_recallTime;
    public float recallTime;
    public bool isActive;
    public string profName;
    public int breadType;
    public int breadNum;
    public Sprite img;

    void Start()
    {
        isActive = false;
        breadType = Random.Range(0, 5);
        profName = namae(breadType);
        this.GetComponent<UnityEngine.UI.Image>().sprite = img;
    }
    void Update()
    {
        if (isActive)
        {
            recallTime -= Time.deltaTime;
            if (recallTime < 0)
            {
                recallTime = 0;
                goHome();
            }
        }
    }
    public void goHome()
    {
        if (breadType != 4)
            GameObject.Find("LifeSystemObject").GetComponent<lifeSystem>().lifeDecrease();

        if (GameObject.Find("SummonProf").GetComponent<Summonprof>().profnum == 2)
        {
            GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[2] = GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[1];
            GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[2].transform.localPosition = new Vector3(6.0f, (-60.0f), 1.1f);
        }
        else if (GameObject.Find("SummonProf").GetComponent<Summonprof>().profnum == 3)
        {
            GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[2] = GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[1];
            GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[1] = GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[0];
            GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[2].transform.localPosition = new Vector3(6.0f, (-60.0f), 1.1f);
            GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[1].transform.localPosition = new Vector3(3.0f, (0.0f), 2.1f);
        }

        GameObject.Find("SummonProf").GetComponent<Summonprof>().profnum -= 1;
        isActive = false;
        Destroy(this.gameObject);
    }

    public string namae(int type)
    {
        int pronamae = Random.Range(0, 3);

        switch (type)
        {
            case 0:
                switch (pronamae)
                {
                    case 0:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[0];
                        return "윤은영";
                    case 1:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[1];
                        return "김종";
                    case 2:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[2];
                        return "김장우";
                    case 3:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[3];
                        return "박성우";
                }
                break;
            case 1:
                switch (pronamae)
                {
                    case 0:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[4];
                        return "이진수";
                    case 1:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[5];
                        return "김진택";
                    case 2:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[6];
                        return "김재준";
                    case 3:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[7];
                        return "정성준";
                }
                break;
            case 2:
                switch (pronamae)
                {
                    case 0:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[8];
                        return "조준호";
                    case 1:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[9];
                        return "이정수";
                    case 2:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[10];
                        return "김경태";
                    case 3:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[11];
                        return "박홍준";
                }
                break;
            case 3:
                switch (pronamae)
                {
                    case 0:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[12];
                        return "주태하";
                    case 1:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[13];
                        return "신승구";
                    case 2:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[14];
                        return "이은성";
                    case 3:
                        img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[15];
                        return "이영민";
                }
                break;
            case 4:
                img = GameObject.Find("SummonProf").GetComponent<Summonprof>().imgs[16];
                return "넙죽이";
        }
        return "Error";
    }
    public void setDifficulty(int _diff)
    {
        if (_diff == 0)
        {
            breadNum = Random.Range(1, 3);
            recallTime = 30;
        }
        else if (_diff == 1)
        {
            breadNum = Random.Range(1, 3);
            recallTime = 25;
        }
        else
        {
            breadNum = Random.Range(2, 3);
            recallTime = 20;
        }
        Max_recallTime = recallTime;
    }
}