using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static string state = "Movement";

    public float HP = 10;
    float maxHP = 10;
    float MP = 10;
    float maxMP = 10;
    float EXP = 0;
    float maxEXP = 10;
    float Str = 10;
    float Dex;
    float Int;
    float AC;
    string Att;

    public static string[] skills = new string[4];

    public Text HPText;
    public Text MPText;
    public Text EXPText;
    public Text HPText2;
    public Text MPText2;
    public Text EXPText2;
    public Text HPText3;
    public Text MPText3;
    public Text StrText;

    public Image HPBar;
    public Image MPBar;
    public Image HPBar2;
    public Image MPBar2;
    public Image HPBar3;
    public Image MPBar3;
    public Image EXPBar;
    public Image EXPBar2;

    // Start is called before the first frame update
    void Start()
    {
        updateAttribute();
    }

    // Update is called once per frame
    void Update()
    {
        updateAttribute();
    }

    private void updateAttribute()
    {
        HPText.text = HP.ToString() + "/" + maxHP.ToString();
        MPText.text = MP.ToString() + "/" + maxMP.ToString();
        EXPText.text = EXP.ToString() + "/" + maxEXP.ToString();
        HPText2.text = HP.ToString() + "/" + maxHP.ToString();
        MPText2.text = MP.ToString() + "/" + maxMP.ToString();
        EXPText2.text = EXP.ToString() + "/" + maxEXP.ToString();
        HPText3.text = HP.ToString() + "/" + maxHP.ToString();
        MPText3.text = MP.ToString() + "/" + maxMP.ToString();
        HPBar.fillAmount = HP / maxHP;
        MPBar.fillAmount = MP / maxMP;
        HPBar2.fillAmount = HP / maxHP;
        MPBar2.fillAmount = MP / maxMP;
        EXPBar.fillAmount = EXP / maxEXP;
        EXPBar2.fillAmount = EXP / maxEXP;
        StrText.text = Str.ToString();
        HPBar3.fillAmount = HP / maxHP;
        MPBar3.fillAmount = MP / maxMP;
    } 
}
