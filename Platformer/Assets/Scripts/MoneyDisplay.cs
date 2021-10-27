using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text cash;
    [SerializeField] private int money = 0;

    void Update()
    {
        //need to implement cash system first before this is fully functional
        cash.text = ("$: " + money.ToString()); 
    }
}
