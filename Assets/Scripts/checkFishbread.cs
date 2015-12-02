using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class checkFishbread : MonoBehaviour {
    public Text uncookedText;
    public Text uncookedTotalText;
    public Text burnedText;
    public Text burnedTotalText;
    public Text citeText;
    public Text citeTotalText;
    public Text cseText;
    public Text cseTotalText;
    public Text chemText;
    public Text chemTotalText;
    public Text eeText;
    public Text eeTotalText;
    public AudioClip fishbreadsound;

    //Number of Total Fishbread;
    int numUncookedTotal;
    int numBurnedTotal;
    int numCITETotal;
    int numCSETotal;
    int numCHEMTotal;
    int numEETotal;

    //Number of checked Fishbread;
    int numUncooked;
    int numBurned;
    int numCITE;
    int numCSE;
    int numCHEM;
    int numEE;

    // Use this for initialization
    void Start () {
        
    }

	public void initializeNumber()
	{
		numUncookedTotal = 0;
		numBurnedTotal = 0;
		numCITETotal = 5;
		numCSETotal = 5;
		numCHEMTotal = 5;
		numEETotal = 5;
		
		//Initialize Checked Fishbread as 0
		numUncooked = 0;
		numBurned = 0;
		numCITE = 0;
		numCSE = 0;
		numCHEM = 0;
		numEE = 0;
		
		uncookedTotalText.text = "" + numUncookedTotal;
		burnedTotalText.text = "" + numBurnedTotal;
		citeTotalText.text = "" + numCITETotal;
		cseTotalText.text = "" + numCSETotal;
		chemTotalText.text = "" + numCHEMTotal;
		eeTotalText.text = "" + numEETotal;
	}

    //Give to Professor fishbread
    public void giveFishBread()
    {
        AudioSource.PlayClipAtPoint(fishbreadsound, transform.position);
        //교수 함수에 인자 전달 
        GameObject.Find("SummonProf").GetComponent<Summonprof>().receiveFishBread(numUncooked, numBurned, numCITE, numCSE, numCHEM, numEE);

        //전체 붕어빵 갯수 줄이기
        numUncookedTotal -= numUncooked;
        numBurnedTotal -= numBurned;
        numCITETotal -= numCITE;
        numCSETotal -= numCSE;
        numCHEMTotal -= numCHEM;
        numEETotal -= numEE;

        //체크된 붕어빵 갯수 초기화
        numUncooked = 0;
        numBurned = 0;
        numCITE = 0;
        numCSE = 0;
        numCHEM = 0;
        numEE = 0;

        //텍스트 업데이트
        uncookedTotalText.text = "" + numUncookedTotal;
        burnedTotalText.text = "" + numBurnedTotal;
        citeTotalText.text = "" + numCITETotal;
        cseTotalText.text = "" + numCSETotal;
        chemTotalText.text = "" + numCHEMTotal;
        eeTotalText.text = "" + numEETotal;

        uncookedText.text = "0";
        burnedText.text = "0";
        citeText.text = "0";
        cseText.text = "0";
        chemText.text = "0";
        eeText.text = "0";
    }

    //덜익은 붕어빵의 체크 갯수를 높인다
    public void incChkUncooked()
    {
        if (numUncookedTotal > numUncooked)
            numUncooked++;

        uncookedText.text = "" +numUncooked;
    }

    //덜익은 붕어빵의 체크 갯수를 줄인다
    public void decChkUncooked()
    {
        if (numUncooked > 0)
            numUncooked--;

        uncookedText.text = "" + numUncooked;
    }

	public void incTotUncooked()
	{
		numUncookedTotal++;
	
		uncookedTotalText.text = "" + numUncookedTotal;
	}

    //탄 붕어빵의 체크 갯수를 높인다
    public void incChkBurned()
    {
        if (numBurnedTotal > numBurned)
            numBurned++;

        burnedText.text = "" + numBurned;
    }

    //탄 붕어빵의 체크 갯수를 줄인다
    public void decChkBurned()
    {
        if (numBurned > 0)
            numBurned--;

        burnedText.text = "" + numBurned;
    }

	public void incTotBurned()
	{
		numBurnedTotal++;
		
		burnedTotalText.text = "" + numBurnedTotal;
	}

    //창공과 붕어빵의 체크 갯수를 높인다
    public void incChkCITE()
    {
        if (numCITETotal > numCITE)
            numCITE++;

        citeText.text = "" + numCITE;
    }

    //창공과 붕어빵의 체크 갯수를 줄인다
    public void decChkCITE()
    {
        if (numCITE > 0)
            numCITE--;

        citeText.text = "" + numCITE;
    }

	public void incTotCITE()
	{
		numCITETotal++;
		
		citeTotalText.text = "" + numCITETotal;
	}

    //컴공과 붕어빵의 체크 갯수를 높인다
    public void incChkCSE()
    {
        if (numCSETotal > numCSE)
            numCSE++;

        cseText.text = "" + numCSE;
    }

    //컴공과 붕어빵의 체크 갯수를 줄인다
    public void decChkCSE()
    {
        if (numCSE > 0)
            numCSE--;

        cseText.text = "" + numCSE;
    }

	public void incTotCSE()
	{
		numCSETotal++;
		
		cseTotalText.text = "" + numCSETotal;
	}

    //화학과 붕어빵의 체크 갯수를 높인다
    public void incChkCHEM()
    {
        if (numCHEMTotal > numCHEM)
            numCHEM++;

        chemText.text = "" + numCHEM;
    }

    //화학과 붕어빵의 체크 갯수를 줄인다
    public void decChkCHEM()
    {
        if (numCHEM > 0)
            numCHEM--;

        chemText.text = "" + numCHEM;
    }

	public void incTotCHEM()
	{
		numCHEMTotal++;
		
		chemTotalText.text = "" + numCHEMTotal;
	}

    //전자과 붕어빵의 체크 갯수를 높인다
    public void incChkEE()
    {
        if (numEETotal > numEE)
            numEE++;

        eeText.text = "" + numEE;
    }

    //전자과 붕어빵의 체크 갯수를 줄인다
    public void decChkEE()
    {
        if (numEE > 0)
            numEE--;

        eeText.text = "" + numEE;
    }

	public void incTotEE()
	{
		numEETotal++;
		
		eeTotalText.text = "" + numEETotal;
	}
}
