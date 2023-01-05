using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class BackpackControl : MonoBehaviour
{
    public Button backpackIcon;
    public Button closeIcon;
    public GameObject backpack;
    
    public GameObject slotPrefab;
    public const int numSlots = 20;
    GameObject[] slots = new GameObject[numSlots];
    Text[] slotTxts = new Text[numSlots];//物品数量
    Item[] items = new Item[numSlots];
    Button[] slotBtns = new Button[numSlots];
    GameObject[] descriptions = new GameObject[numSlots];
    Button[] useBtns = new Button[numSlots];
    Button[] discardBtns = new Button[numSlots];

    Item weapon;

    public Item redPotion;
    public Item woodenSword;
    // Start is called before the first frame update
    void Start()
    {
        CreateSlots();
        AddItem(redPotion);
        AddItem(redPotion);
        AddItem(redPotion);
        AddItem(woodenSword);

    }

    // Update is called once per frame
    void Update()
    {
        backpackIcon.onClick.AddListener(delegate ()
        {
            Player.state = "Backpack";
            backpack.SetActive(true);
        });
        closeIcon.onClick.AddListener(delegate ()
        {
            for (int j = 0; j < numSlots; j++)
            {
                descriptions[j].SetActive(false);
            }
            backpack.SetActive(false);
            Player.state = "Movement";
        });
    }

    private void CreateSlots()
    {
        if (slotPrefab != null)
        {
            for (int i = 0; i < numSlots; i++)
            {
                GameObject newSlot = Instantiate(slotPrefab);
                newSlot.name = "ItemSlot_" + i;
                newSlot.transform.SetParent(gameObject.transform.GetChild(0).GetChild(0).transform);
                newSlot.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                slots[i] = newSlot;

                slotTxts[i] = slots[i].GetComponent<Slot>().qtyText;
                slotBtns[i] = slots[i].GetComponent<Slot>().slotBtn;
                descriptions[i] = slots[i].GetComponent<Slot>().Description;
                useBtns[i] = slots[i].GetComponent<Slot>().Use;
                discardBtns[i] = slots[i].GetComponent<Slot>().Discard;

                int temp = i;
                slotBtns[i].onClick.AddListener(delegate ()
                {
                    for (int j = 0; j < numSlots; j++)
                    {
                        descriptions[j].SetActive(false);
                    }
                    if (items[temp]!=null)
                    {
                        descriptions[temp].SetActive(true);
                    }
                });
                useBtns[i].onClick.AddListener(delegate ()
                //使用道具
                {
                    
                    descriptions[temp].SetActive(false);
                    
                });
                discardBtns[i].onClick.AddListener(delegate ()
                //丢弃道具
                {
                    DropItem(temp);
                    descriptions[temp].SetActive(false);
                });

            }
        }
    }

    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < numSlots; i++)
        {
            if (items[i] != null && items[i].itemType == itemToAdd.itemType)//如果格子不为空并且格中物品与获取物品种类相同
            {
                if (items[i].stackable == true)//如果此物品可以堆叠
                {
                    items[i].quantity += 1;
                    slotTxts[i].text = items[i].quantity.ToString();
                    return;
                    //数量+1，并且重置文本
                }
                else
                {
                    return;
                }
            }
        }

        for (int i = 0; i < numSlots; i++)
        {
            if (items[i] == null)
            {
                items[i] = Instantiate(itemToAdd);
                items[i].quantity += 1;
                slotBtns[i].image.sprite = itemToAdd.sprite;
                if (items[i].stackable == true)
                {
                    slotTxts[i].text = items[i].quantity.ToString();
                    return;
                }
                else
                {
                    return;
                }
            }
        }
        return;
    }
    private void DropItem(int index)
    {
        if (items[index] == null)
        {
            return;
        }
        else
        {
            if (items[index].stackable == true)
            {
                items[index].quantity -= 1;
                slotTxts[index].text = items[index].quantity.ToString();
                switch (items[index].itemType)
                {

                    default:
                        break;
                }
                if (items[index].quantity <= 0)
                {
                    items[index] = null;
                    slotBtns[index].image.sprite = null;
                    slotBtns[index].enabled = false;
                    slotTxts[index].text = "";
                }
            }
            else
            {
                items[index].quantity -= 1;
                items[index] = null;
                slotBtns[index].image.sprite = null;
                slotBtns[index].enabled = false;
                slotTxts[index].text = "";

            }
        }

    }
}
