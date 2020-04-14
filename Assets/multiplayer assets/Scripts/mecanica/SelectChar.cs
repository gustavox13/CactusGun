using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour
{

    public static string CurrentChar;

    public const string CHAR1 = "char1";
    public const string CHAR2 = "char2";
    public const string CHAR3 = "char3";




    public void SelectChar1()
    {
        CurrentChar = CHAR1;
    }

    public void SelectChar2()
    {
        CurrentChar = CHAR2;
    }

    public void SelectChar3()
    {
        CurrentChar = CHAR3;
    }
}
