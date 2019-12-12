using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimationMap : MonoBehaviour
{
    [SerializeField]
    private Animator mapOpen;

    [SerializeField]
    private GameObject buttonsMap;

    [SerializeField]
    private GameObject buttonBack;

    private void Start()
    {
        OcultButtonsMap();

        mapOpen.SetBool("openMap", true);

        apearsButtonsMap();
    }

    //OCULTA BOTOES DO MAPA
    public void OcultButtonsMap()
    {
        buttonsMap.SetActive(false);
        buttonBack.SetActive(false);
        mapOpen.SetBool("openMap", false);
    }

    //EXIBE BOTOES DO MAPA
    public void apearsButtonsMap()
    {
        mapOpen.SetBool("openMap", true);
        StartCoroutine(ApersButtonsCoroutine());
    }

    private IEnumerator ApersButtonsCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        buttonsMap.SetActive(true);
        buttonBack.SetActive(true);
    }

}
