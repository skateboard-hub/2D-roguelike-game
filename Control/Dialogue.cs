using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text dialogueText;
    public Button optionA;
    public GameObject dialogue;
    public GameObject battleField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        optionA.onClick.AddListener(delegate ()
        {
            dialogue.SetActive(false);
            Player.state = "Battle";
            battleField.SetActive(true);
        });
        
    }
}
