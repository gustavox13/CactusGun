using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMenuControler : MonoBehaviour
{
    [SerializeField]
    private GameObject cactusLogo;
    [SerializeField]
    private GameObject gunLogo;
    [SerializeField]
    private GameObject duelButton;
    [SerializeField]
    private GameObject shopButton;

    void Start()
    {
        cactusLogo.SetActive(false);
        gunLogo.SetActive(false);
        duelButton.SetActive(false);
        shopButton.SetActive(false);

        StartCoroutine(TimeToShowMenu());
    }

    private IEnumerator TimeToShowMenu()
    {
        yield return new WaitForSeconds(3.0f);
        cactusLogo.SetActive(true);
        gunLogo.SetActive(true);
        duelButton.SetActive(true);
        shopButton.SetActive(true);
    }
}
