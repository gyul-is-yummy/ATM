using System;
using UnityEngine;
using UnityEngine.UI;

public class NumberFormat : MonoBehaviour
{
    public Text balanceText;

    private int balance;
    public int Balance
    {
        get { return balance; }
        set
        {
            balance = value;
            balanceText.text = Formating(balance);
            Test();
        }
    }

    public Text cashText;
    private int cash;
    public int Cash
    {
        get { return cash; }
        set
        {
            cash = value;
            cashText.text = Formating(cash);
        }
    }

    public Text userName;
    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            userName.text = _name;
        }
    }

    public Action UIRefresh;

    private string Formating(int num)
    {
        return string.Format("{0:N0}", num); 
    }

    public void Test()
    {
        Debug.Log("프로퍼티가 제대로 작동함");
    }

    private void Start()
    {
        Balance = 10000;
    }
}
