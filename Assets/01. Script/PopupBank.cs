using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    [SerializeField] private GameObject UI_Deposit;
    [SerializeField] private GameObject UI_Withdraw;
    [SerializeField] private GameObject ATM;
    [SerializeField] private GameObject popupError;

    public InputField inputDeposit;
    public InputField inputWithdraw;

    private void OnValidate() 
    {
        UI_Deposit = transform.Find("Deposit").gameObject;
        UI_Withdraw = transform.Find("Withdraw").gameObject;
        ATM = transform.Find("ATM").gameObject;
        popupError = transform.Find("PopupError").gameObject;
    }

    private void Start()
    {
        ATM.SetActive(true);
        UI_Deposit.SetActive(false);
        UI_Withdraw.SetActive(false);
        popupError.SetActive(false);
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
        ATM.SetActive(true);
    }

    public void Withdraw(int money)
    {
        if(GameManager.Instance.Balance < money)
        {
            ErrorPopup();
            return;
        }

        GameManager.Instance.Balance -= money;
        GameManager.Instance.Cash += money;
    }

    public void Deposit(int money)
    {
        if (GameManager.Instance.Cash < money)
        {
            ErrorPopup();
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

    public void ErrorPopup()
    {
        popupError.SetActive(true);
    }

    public void OnClickErrorBtn()
    {
        popupError.SetActive(false);
    }
}

