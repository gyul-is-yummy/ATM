using UnityEngine;
using System.IO; // 파일 입출력을 위한 네임스페이스

public static class DataManager
{
    public static void Save(UserData data)
    {
        // 저장 폴더가 존재하지 않으면 생성
        if (!Directory.Exists(Application.persistentDataPath + $"/UserData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + $"/UserData");
        }

        // saveDataf JSON 문자열로 변환
        string saveData = JsonUtility.ToJson(data, true); // true: 보기 좋은 포맷(줄 바꿈 포함)

        // JSON 문자열을 파일로 저장
        File.WriteAllText(Application.persistentDataPath + $"/UserData/{data.userName}.txt", saveData);

        Debug.Log("데이터 저장됨");
        Debug.Log(Application.persistentDataPath);
    }

    public static UserData Load(string userName)
    {
        //사용자 데이터가 없으면 기본 데이터를 들려 보내줌
        if (!File.Exists(Application.persistentDataPath + $"/UserData/{userName}.txt"))
        {
            Debug.Log($"사용자 {userName}의 데이터가 없습니다! 기본 데이터를 생성합니다.");

            return new UserData("윤혜진", 100000, 50000);
        }

        string loadData = File.ReadAllText(Application.persistentDataPath + $"/UserData/{userName}.txt");

        Debug.Log($"사용자 {userName} 데이터 로드됨");
        return JsonUtility.FromJson<UserData>(loadData);
    }
}