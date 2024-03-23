using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Collectables : MonoBehaviour
{
    // Private Attributes
    private int _coins;

    // Public Attributes
    public TMP_Text coinText;

    private void Update()
    {
        coinText.text = string.Format("x {0}", _coins);
    }

    public void AddCoin()
    {
        _coins++;
    }
}
