using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string userName;
    public int usercash;
    public int bankBalance;

    public string userID;
    public string userPW;

    public UserData(string _name, int _cash, int _bankBalance, string _id, string _pw)
    {
        userName = _name;
        usercash = _cash;
        bankBalance = _bankBalance;

        userID = _id;
        userPW = _pw;
    }
}
