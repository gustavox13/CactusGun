using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TamborRotate : MonoBehaviour {


    public int CurrentAtk
    {
        get { return currentAtk; }
        set { currentAtk = value; }
    }
    private int currentAtk = 1;



    private int firstHability = 0;
    private int lastHability = 2;
    [SerializeField]
    private Animator tamborAnim;

    private Vector2 firstPressPos;

    [SerializeField]
    private GameObject SwipeField;

    [SerializeField]
    private GameObject[] weapons;
    private AudioSource source;

   // [SerializeField]
    //private Text[] qtd; //0 armadilha // 1 dinamite
   



    private void Awake()
    {
        //qtd[2].enabled = true;
        
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (SwipeField.GetComponent<SwipeField>().InField)
        {
            WhenInputTouch();
        }
    }

    private void WhenInputTouch()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                var secondPressPos = new Vector2(t.position.x, t.position.y);
                var currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                currentSwipe.Normalize();

                //SWIPE LEFT
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    RightMove();
                    source.Play();
                    //UmDebug();



                }
                //SWIPE RIGHT
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    LeftMove();
                    source.Play();
                   // UmDebug();
                }
            }
        }
    }

    public void RightMove()
    {
       if(currentAtk < lastHability)
        {
            currentAtk++;
        }
        else
        {
            currentAtk = firstHability;
        }
        tamborAnim.SetTrigger("right");
    }

    public void LeftMove()
    {
        if (currentAtk > firstHability)
        {
            currentAtk--;
        }
        else
        {
            currentAtk = lastHability;
        }
        tamborAnim.SetTrigger("left");
    }


    public void UmDebug()
    {
        DesativaArmas();

        if (currentAtk == 0)
        {
            Debug.Log("bomba");
            weapons[0].SetActive(true);
            //qtd[1].text = ("" + GameObject.Find("ADS").GetComponentInChildren<AcountController>().CompraDinamite);
            //qtd[1].enabled = true;
            //item.transform. = itens[0];
        }
        if (currentAtk == 1)
        {
           //// qtd[2].enabled = true;
            Debug.Log("atk basico");
            weapons[1].SetActive(true);
        }
        if (currentAtk == 2)
        {
           // qtd[2].enabled = true;
           // qtd[2].text = ("" + GameObject.Find("ADS").GetComponentInChildren<AcountController>().CompraArmadilha);

            Debug.Log("armadilha");
            weapons[2].SetActive(true);
        }
    }

    private void DesativaArmas()
    {
        weapons[0].SetActive(false);
        weapons[1].SetActive(false);
        weapons[2].SetActive(false);
        //qtd[0].enabled = false;
        //qtd[1].enabled = false;
        //qtd[2].enabled = false;
    }

}
