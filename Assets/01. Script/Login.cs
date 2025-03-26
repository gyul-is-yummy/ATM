using UnityEngine;
using UnityEngine.UI;

#nullable enable

public class Login : MonoBehaviour
{
    public InputField loginField_ID;
    public InputField loginField_PW;

    public void Start()
    {
        this.gameObject.SetActive(true);
    }

    public void OnClickLoginBtn()
    {
        UserData? user = DataManager.Load(loginField_ID.text);

        if (user == null)
        {
            GameManager.Instance.popupBank.ErrorPopup("존재하지 않는 회원입니다.");
            return;
        }
        else if(user.userPW != loginField_PW.text)
        {
            GameManager.Instance.popupBank.ErrorPopup("올바르지 않은 비밀번호입니다.");
            return;
        }

        GameManager.Instance.StartBank(user);
        this.gameObject.SetActive(false);
    }
}
