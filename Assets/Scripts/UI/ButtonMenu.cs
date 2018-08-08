using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour {

    [SerializeField]
    private Animator animatorSelectStage;
    [SerializeField]
    private Animator animatorSaloonSelectStage;
    [SerializeField]
    private Animator animatorButtonHiden;
    [SerializeField]
    private Animator animatorButtonShopHiden;

    [SerializeField]
    private Canvas canvasShop;

  

    public void DuelPress()
    {
        animatorSelectStage.SetBool("SelectStage", true);
        animatorSaloonSelectStage.SetBool("MoveSaloon", true);
        animatorButtonHiden.SetBool("ButtonHiden", true);
        animatorButtonShopHiden.SetBool("ButtonShopHiden", true);
    }

    public void BackSelectStagePress()
    {
        animatorSelectStage.SetBool("SelectStage", false);
        animatorSaloonSelectStage.SetBool("MoveSaloon", false);
        animatorButtonHiden.SetBool("ButtonHiden", false);
        animatorButtonShopHiden.SetBool("ButtonShopHiden", false);
        //Test Git
    }

    public void ShopPress()
    {
        
        animatorButtonShopHiden.SetBool("ButtonShopHiden", false);
        canvasShop.gameObject.SetActive(true);
    }

    public void MenuPress()
    {
        canvasShop.gameObject.SetActive(false);
        
    }


    public void GoPress()
    {
        StartCoroutine(Timer());
       
    }

    private IEnumerator Timer()
    {
       yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Lvl1");
    }

    public void ShowAchievementsUI()
    {
        PlayServices.ShowAchivement();
    }


}
