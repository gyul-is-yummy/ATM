using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string userName;
    public int usercash;
    public int bankBalance;
    public UserData(string _name, int _cash, int _bankBalance)
    {
        userName = _name;
        usercash = _cash;
        bankBalance = _bankBalance;
    }
}
