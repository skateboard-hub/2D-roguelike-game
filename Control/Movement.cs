using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.UI;

public class Movement: MonoBehaviour
{
    float step = 1;
    public float moveSpeed = 3.0f;
    private Vector2 movDir = new Vector2();
    private Rigidbody2D rb2d;
    private Animator anim;
    public GameObject player;
    GameObject obj;
    private int temp = 0;
    Vector3 des = new Vector3(0.0f,0.0f,-1.0f);
    public Image difficulty;
    public GameObject dialogue;
    int last = 0;
    public Button optionB;
    public Button Escape;
    public GameObject battleField;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        optionB.onClick.AddListener(delegate ()
        {
            dialogue.SetActive(false);
            //LastLocation();
            Player.state = "Movement";
        });

        Escape.onClick.AddListener(delegate ()
        {
            battleField.SetActive(false);
            //LastLocation();
            Player.state = "Movement";
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Player.state == "Movement")
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                for (int i = 0; i < GenerateEvents.numEvents; i++)
                {
                    if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Event_" + i)
                    {
                        //Debug.Log(1);
                        //Debug.Log(System.Math.Abs(temp - i));
                        if (System.Math.Abs(temp - i) == 1 || System.Math.Abs(temp - i) == 6)//如果格子相邻
                        {
                            step++;
                            if (step % 4 == 0)
                            {
                                difficulty.fillAmount = step / 20;
                            }
                            //步数没满四次增加一次难度
                            last = temp;
                            obj = GameObject.FindGameObjectWithTag("Event_" + i);
                            temp = i;
                            Vector3 offset = new Vector3(0.0f, 0.3f, 0.0f);
                            des = obj.transform.position + offset;
                            movDir = obj.transform.position - player.transform.position;
                            //移动

                            if (GenerateEvents.eventType[i] != null)
                            {
                                dialogue.SetActive(true);
                                Player.state = "Dialogue";
                            }
                            //触发对话
                        }

                    }
                }
            }
            
        }
        UpdateState();
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        if (des[2] != -1.0f)
        {
            movDir.Normalize();
            transform.position = Vector2.MoveTowards(transform.position, des, Time.deltaTime * moveSpeed);
        }

    }

    private void UpdateState()
    {
        if (des[2] != -1.0f)
        {
            if (Mathf.Approximately(des.x, player.transform.position[0]) && Mathf.Approximately(des.y, player.transform.position[1]))
            {
                anim.SetBool("isWalking", false);
            }
            else
            {
                anim.SetFloat("xDir", movDir.x);
                anim.SetFloat("yDir", movDir.y);
                anim.SetBool("isWalking", true);
            }
        }
        
    }

    private void LastLocation()
    {
        temp = last;
        obj = GameObject.FindGameObjectWithTag("Event_" + last);
        Vector3 offset = new Vector3(0.0f, 0.3f, 0.0f);
        des = obj.transform.position + offset;
        movDir = obj.transform.position - player.transform.position;
    }
}
