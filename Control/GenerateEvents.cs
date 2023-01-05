using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GenerateEvents : MonoBehaviour
{
    public GameObject EventPrefab;
    public GameObject Null;
    public GameObject Chest;
    public GameObject Grave;
    public GameObject Boss;

    public static int numEvents = 30;
    GameObject[] events = new GameObject[numEvents];
    public static string[] eventType = new string[numEvents];
    // Start is called before the first frame update
    void Start()
    {
        CreateEvents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateEvents()
    {
        if (EventPrefab != null)
        {
            System.Random rd = new System.Random();
            int j = rd.Next(1, 29);
            for (int i = 0; i < numEvents; i++)
            {
                GameObject newEvent;
                if (i == 0 || i == j)
                {
                    if (i == 0)
                    {
                        newEvent = Instantiate(EventPrefab);
                        eventType[i] = "Goddness";
                    }
                    else
                    {
                        newEvent = Instantiate(Boss);
                        eventType[i] = "Boss";
                    }
                }
                else
                {
                    int possibility = rd.Next(1, 11);
                    if (possibility < 9)
                    {
                        switch (possibility)
                        {
                            case 1:
                                newEvent = Instantiate(Grave);
                                eventType[i] = "Grave";
                                break;
                            default:
                                newEvent = Instantiate(Chest);
                                eventType[i] = "Chest";
                                break;
                        }
                    }
                    else
                    {
                        newEvent = Instantiate(Null);
                    }
                    
                }
                AddTag("Event_" + i, newEvent);
                newEvent.tag = "Event_" + i;
                newEvent.name = "Event_" + i;
                newEvent.transform.SetParent(gameObject.transform);
                events[i] = newEvent;
            }
        }
    }
    void AddTag (string tag,GameObject obj)
    {
        if (!isHasTag(tag))
        {
            SerializedObject tagManager = new SerializedObject(obj);
            SerializedProperty it = tagManager.GetIterator();
            while (it.NextVisible(true))
            {
                if(it.name == "m_TagString")
                {
                    it.stringValue = tag;
                    tagManager.ApplyModifiedProperties();
                }
            }
        }
    }

    bool isHasTag(string tag)
    {
        for (int i = 0; i < UnityEditorInternal.InternalEditorUtility.tags.Length; i++)
        {
            if (UnityEditorInternal.InternalEditorUtility.tags[i].Equals(tag)){
                return true;
            }
        }
        return false;
    }

}
