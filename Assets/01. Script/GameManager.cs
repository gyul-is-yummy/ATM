using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
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

    private void Start()
    {
        //userData = new UserData("윤혜진", 100000, 50000);
        userData = DataManager.Load("윤혜진");
        Refresh();

        DataManager.Save(userData);

    }

    //인스펙터 창에서 값이 변경될 때마다 실행된다?
    private void OnValidate()
    {
        //Refresh();
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
