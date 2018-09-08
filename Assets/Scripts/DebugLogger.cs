using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI상에서 Text를 이용해 Debug.Log를 확인해보고 싶다면 아무 게임오브젝트에 붙여서 사용 가능(adb의 logcat -s Unity를 쓰기 귀찮을 때라던가).
public class DebugLogger : MonoBehaviour {

    private Text text;

    void Awake()
    {
        //Hierarchy에 UI.Text 컴포넌트가 있으면 찾아서 할당.
        text = GameObject.Find("__DebugText").GetComponent<Text>();
    }

    //GameObject가 활성화될 때 OnEnable(), 비활성화될 때 OnDisable()을 쓴다.
    void OnEnable()
    {
        //Application(유니티 게임 자체)의 logMesssageReceived라는 이벤트(원래는 Debug.Log를 콘솔창에 출력해줌)에 하단에 새로 만든 LogMessage()를 새로 추가.
        //앞으로 logMessageReceived라는 이벤트가 호출될 때마다(= Debug.Log()를 호출) 밑에 있는 LogMessage()도 같이 호출하겠다는 뜻(이를 Delegate Chain이라고 부름).
        Application.logMessageReceived += LogMessage;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= LogMessage;
    }

    //logMessageReceived라는 이벤트는 LogCallback이라는 델리게이트만 받는데 이 LogCallback의 함수는 
    //public delegate void LogCallback(string condition, string stackTrace, LogType type);
    //의 형태로 되어 있음. 그래서 아래 함수도 같은 입출력형을 맞춰서 함수로 만듬(그래야 logMessageReceived 이벤트에 Delegate Chain을 추가 가능).
    public void LogMessage(string msg, string stackTrace, LogType type)
    {
        //msg에는 Debug.Log(msg), 즉 로그로 남길 string이 들어가므로 msg를 위에서 찾아낸 Text의 text에 넣어주는 함수.
        //Debug.Log()를 호출할 때마다 이 함수도 같이 호출됨.
        text.text = msg + "\n";
    } 

}
