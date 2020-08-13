using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverHUD : MonoBehaviour
{

    [SerializeField]
    private Animator tamborAnim;

    [SerializeField]
    private Animator revolverAnim;

    private Vector2 firstPressPos;

    [SerializeField]
    private GameObject basicSkill; // codigo 1
    [SerializeField]
    private GameObject tntSkill; // codigo 2
    [SerializeField]
    private GameObject trapSkill; // codigo 3

    public int CurrentSkill;


    private void Start()
    {
        tntSkill.SetActive(false);
        trapSkill.SetActive(false);

        CurrentSkill = 1;
    }


    private void Update()
    {
        WhenInputTouch();
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
                   
                }
                //SWIPE RIGHT
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    LeftMove();
                   

                }
            }
        }
    }

    public void RightMove()
    {
        if (CurrentSkill == 1)
        {
            CurrentSkill = 2;
            
            //ATIVA
            tntSkill.SetActive(true);
            //DESATIVA
            basicSkill.SetActive(false);
            trapSkill.SetActive(false);

            Debug.Log(CurrentSkill);

        }
        else if(CurrentSkill == 2)
        {
            CurrentSkill = 3;

            //ATIVA
            trapSkill.SetActive(true);
            //DESATIVA
            basicSkill.SetActive(false);
            tntSkill.SetActive(false);

            Debug.Log(CurrentSkill);
        }
        else if (CurrentSkill == 3)
        {
            CurrentSkill = 1;

            //ATIVA
            basicSkill.SetActive(true);
            //DESATIVA
            trapSkill.SetActive(false);
            tntSkill.SetActive(false);

            Debug.Log(CurrentSkill);
        }
        

        revolverAnim.SetTrigger("left");
        tamborAnim.SetTrigger("left");
    }

    public void LeftMove()
    {
        if (CurrentSkill == 1)
        {
            CurrentSkill = 3;

            //ATIVA
            trapSkill.SetActive(true);
            //DESATIVA
            basicSkill.SetActive(false);
            tntSkill.SetActive(false);

            Debug.Log(CurrentSkill);

        }
        else if (CurrentSkill == 3)
        {
            CurrentSkill = 2;

            //ATIVA
            tntSkill.SetActive(true);
            //DESATIVA
            basicSkill.SetActive(false);
            trapSkill.SetActive(false);

            Debug.Log(CurrentSkill);
        }
        else if (CurrentSkill == 2)
        {
            CurrentSkill = 1;

            //ATIVA
            basicSkill.SetActive(true);
            //DESATIVA
            trapSkill.SetActive(false);
            tntSkill.SetActive(false);

            Debug.Log(CurrentSkill);
        }

        revolverAnim.SetTrigger("right");
        tamborAnim.SetTrigger("right");
    }


}
