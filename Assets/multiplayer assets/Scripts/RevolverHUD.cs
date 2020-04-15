using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverHUD : MonoBehaviour
{
    [SerializeField]
    private Animator tamborAnim;

    [SerializeField]
    private Animator revolverAnim;

    private Vector2 firstPressPos;


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
        revolverAnim.SetTrigger("left");
        tamborAnim.SetTrigger("left");
    }

    public void LeftMove()
    {
        revolverAnim.SetTrigger("right");
        tamborAnim.SetTrigger("right");
    }


}
