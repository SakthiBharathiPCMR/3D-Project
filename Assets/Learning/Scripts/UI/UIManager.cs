using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UIManager : MonoBehaviour
{

    public Image fillImg;
    public TMP_Text filltxt;
    public List<WeaponData> weaponDatas;

    internal float lvlNum;
    internal float lastFillAmt;

    internal int lastRewLvl;
    internal int curRewLvl;
    internal int rewFreq = 10;
    internal int indx;

    private void Start()
    {
        weaponDatas = Resources.LoadAll<WeaponData>("Data").ToList();
        curRewLvl += rewFreq;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            lvlNum++;
            if (lvlNum > curRewLvl)
            {
                lastRewLvl = curRewLvl;
                curRewLvl += rewFreq;
                indx++;
                indx %= weaponDatas.Count;
                SetRewardData(indx);
            }
            FillUI();
        }

    }

    private void SetRewardData(int indx)
    {
        fillImg.sprite = weaponDatas[indx].weponSpr;
    }

    private void FillUI()
    {
        lastFillAmt = Mathf.InverseLerp(lastRewLvl, curRewLvl, lvlNum);
        fillImg.fillAmount = lastFillAmt;
        filltxt.text = Mathf.InverseLerp(lastRewLvl, curRewLvl, lvlNum) * 100f + " % Completed";
    }

    


}
