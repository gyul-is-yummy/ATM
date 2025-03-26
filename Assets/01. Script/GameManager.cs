using UnityEngine;
using UnityEngine.UI;
using System;

//현재 이용자가 어느 상태에 머물러 있는지 
public enum State
{
    Login,
    SignUp,
    Bank
}


public class GameManager : MonoBehaviour
{
    public State state = State.Login;

    public PopupBank popupBank;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        { 
            if (instance == null)
            {
                var go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    public UserData userData;

    public Text balanceText;
    public int Balance
    {
        get { return userData.bankBalance; }
        set
        {
            if (value < 0) return;

            userData.bankBalance = value;
            balanceText.text = userData.bankBalance.ToString("N0");
        }
    }

    public Text cashText;
    public int Cash
    {
        get { return userData.usercash; }
        set
        {
            if (value < 0) return;

            userData.usercash = value;
            cashText.text = userData.usercash.ToString("N0");
            DataManager.Save(userData);
        }
    }

    public Text userName;
    public string Name
    {
        get { return userData.userName; }
        set
        {
            userData.userName = value;
            userName.text = userData.userName;
        }
    }

    private void Awake()
    {
        //인스턴스가 비어있다면 할당해주고,
        //해당 오브젝트를 씬 이동간 파괴하지 않도록 해준다.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //이미 할당되어 있다면 파괴
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartBank(UserData user)
    {
        userData = user;
        Refresh();
        popupBank.BackOpen();
    }

    public void NameRefresh()
    {
        Name = userData.userName;
    }

    public void BanlanceRefresh()
    {
        Balance = userData.bankBalance;
    }

    public void CashRefresh()
    {
        Cash = userData.usercash;
    }

    public void Refresh()
    {
        NameRefresh();
        BanlanceRefresh();
        CashRefresh();
    }

}
