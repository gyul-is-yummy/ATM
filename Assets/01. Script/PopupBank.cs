using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable enable

public struct temp
{
    public InputField input;
    public int money;
}

public class PopupBank : MonoBehaviour
{
    [SerializeField] private GameObject UI_Deposit;
    [SerializeField] private GameObject UI_Withdraw;
    [SerializeField] private GameObject UI_Send;
    [SerializeField] private GameObject ATM;
    [SerializeField] private GameObject popupError;
    [SerializeField] private GameObject userInfo;
    [SerializeField] private GameObject userCash;

    //public InputField inputDeposit;
    //public InputField inputWithdraw;

    public InputField opponentID;
    public InputField sendMoney;

    public Text errorText;

    private void OnValidate() 
    {
        UI_Deposit = transform.Find("Deposit").gameObject;
        UI_Withdraw = transform.Find("Withdraw").gameObject;
        UI_Send = transform.Find("Send").gameObject;
        ATM = transform.Find("ATM").gameObject;

        popupError = transform.Find("PopupError").gameObject;
        userInfo = transform.Find("UserInfo").gameObject;
        userCash = transform.Find("UserCash").gameObject;
    }

    private void Start()
    {
        UI_Send.SetActive(false);
        ATM.SetActive(false);
        UI_Deposit.SetActive(false);
        UI_Withdraw.SetActive(false);
        popupError.SetActive(false);
        userInfo.SetActive(false);
        userCash.SetActive(false);
    }

    public void BackOpen()
    {
        ATM.SetActive(true);
        userInfo.SetActive(true);
        userCash.SetActive(true);
    }

    public void OnClickSelectDepositBtn()
    {
        UI_Deposit.SetActive(true);
        ATM.SetActive(false);
    }

    public void OnClickSelectWithdrawBtn()
    {
        UI_Withdraw.SetActive(true);
        ATM.SetActive(false);
    }

    public void OnClickBackBtn()
    {
        UI_Withdraw.SetActive(false);
        UI_Deposit.SetActive(false);
        UI_Send.SetActive(false);

        ATM.SetActive(true);
    }

    public void OnClickSelectSendBtn()
    {
        UI_Send.SetActive(true);
        ATM.SetActive(false);
    }

    public void Withdraw(int money)
    {
        if(GameManager.Instance.Balance < money)
        {
            ErrorPopup("잔액이 부족합니다.");
            return;
        }

        GameManager.Instance.Balance -= money;
        GameManager.Instance.Cash += money;
    }

    public void Deposit(int money)
    {
        if (GameManager.Instance.Cash < money)
        {
            ErrorPopup("잔액이 부족합니다.");
            return;
        }

        GameManager.Instance.Balance += money;
        GameManager.Instance.Cash -= money;
    }

    public void CustomWithdraw(InputField inputText)
    {
        if(int.TryParse(inputText.text, out int money))
        {
            Withdraw(money);
            inputText.text = "";
        }
    }

    public void CustomDeposit(InputField inputText)
    {
        if (int.TryParse(inputText.text, out int money))
        {
            Deposit(money);
            inputText.text = "";
        }
    }

    public void ErrorPopup(string message)
    {
        errorText.text = message;
        popupError.SetActive(true);   
    }

    public void OnClickErrorBtn()
    {
        popupError.SetActive(false);
    }

    public void OnClickPopupBtn(GameObject popupObj)
    {
        popupObj.SetActive(true);
    }

    public void OnClickCancelBtn(GameObject popupObj)
    {
        popupObj.SetActive(false);
    }

    public void OnClickSendBtn()
    {
        //입금할 상대의 정보를 불러옴
        UserData? user = DataManager.Load(opponentID.text);
        int money = int.Parse(sendMoney.text); 

        if (user == null)
        {
            ErrorPopup("대상이 없습니다.");
            return;
        }
        if(GameManager.Instance.Balance < money)
        {
            ErrorPopup("잔액이 부족합니다.");
            return;
        }

        //Load한 상대 계좌에 입금
        user.bankBalance += money;
        //내 계좌에서 입금하는 만큼의 돈을 차감
        GameManager.Instance.Balance -= money;

        //Load하고 수정한 유저 정보를 저장
        DataManager.Save(user);

        Debug.Log($"{user.userID}에게 {money}원 송금완료");
        ErrorPopup("송금완료");
    }
}

