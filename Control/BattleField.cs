using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleField : MonoBehaviour
{
    public Button skills;
    public GameObject displaySkills;
    public Button Return;
    public GameObject options;
    // Start is called before the first frame update
    void Start()
    {
        skills.onClick.AddListener(delegate ()
        {
            displaySkills.SetActive(true);
            options.SetActive(false);
        });
        Return.onClick.AddListener(delegate ()
        {
            displaySkills.SetActive(false);
            options.SetActive(true);
        });
    }
        // Update is called once per frame
    void Update()
    {
        
    }
}
