using UnityEngine;
using System.Collections;

public class prof : MonoBehaviour
{
    public float recallTime;
    public bool isActive;
    public string profName;
    public int breadType;
    public int breadNum;

    void Start()
    {
        isActive = false;
        breadType = Random.Range(0, 5);
        profName = namae(breadType);
        recallTime = Random.Range(10, 15);
        breadNum = Random.Range(1, 4);
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
        if (GameObject.Find("SummonProf").GetComponent<Summonprof>().profnum == 2)
        {
            GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[2] = GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[1];
            GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[2].transform.Translate(0,-10,0);
        }
        else if (GameObject.Find("SummonProf").GetComponent<Summonprof>().profnum == 3)
        {
            GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[2] = GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[1];
            GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[1] = GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[0];
            GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[2].transform.Translate(0, -10, 0);
            GameObject.Find("SummonProf").GetComponent<Summonprof>().prof[1].transform.Translate(0, -10, 0);
        }

        GameObject.Find("SummonProf").GetComponent<Summonprof>().profnum -= 1;
        isActive = false;
        Destroy(this.gameObject);
    }

    public string namae(int type)
    {
        int pronamae = Random.Range(0,3);

        switch(type)
        {
            case 0:
                switch (pronamae)
                {
                    case 0:
                        return "윤은영";
                    case 1:
                        return "김종";
                    case 2:
                        return "김장우";
                    case 3:
                        return "박성우";
                }
                break;
            case 1:
                switch (pronamae)
                {
                    case 0:
                        return "이진수";
                    case 1:
                        return "김진택";
                    case 2:
                        return "김재준";
                    case 3:
                        return "정성준";
                }
                break;
            case 2:
                switch (pronamae)
                {
                    case 0:
                        return "조준호";
                    case 1:
                        return "이정수";
                    case 2:
                        return "김경태";
                    case 3:
                        return "박홍준";
                }
                break;
            case 3:
                switch (pronamae)
                {
                    case 0:
                        return "주태하";
                    case 1:
                        return "신승구";
                    case 2:
                        return "이은성";
                    case 3:
                        return "이영민";
                }
                break;
            case 4:
                return "넙죽이";
        }
        return "Error";
    }
}
