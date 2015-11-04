using UnityEngine;
using System.Collections;

public class prof : MonoBehaviour
{

    public float recallTime;
    public bool isActive;
    public string profName;
    public int breadType;

    void Start()
    {
        isActive = false;
        profName = "";
        breadType = 0;
        recallTime = 0;
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
    public void load(string name, int breadType, int recallTime)
    {
        this.profName = name;
        this.breadType = breadType;
        this.recallTime = recallTime;
    }
    public void goHome()
    {

    }
}
