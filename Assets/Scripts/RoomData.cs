using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomData : MonoBehaviour
{
    private RoomInfo _roomInfo;
    // 하위에 있는 TMP_Text를 저장할 변수
    private TMP_Text roomInfoText;
    // PhotonManager 접근 변수
    private PhotonManager photonManager;

    // 프로퍼티 정의
    public RoomInfo RoomInfo
    {
        get
        {
            return _roomInfo;
        }
        set
        {
            _roomInfo = value;
            // 룸 정보 표시
            roomInfoText.text = $"{_roomInfo.Name} ({_roomInfo.PlayerCount}/{_roomInfo.MaxPlayers})";
            // 버튼 클릭 이벤트에 함수 연결
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnEnterRoom(_roomInfo.Name));
        }
    }

    void Awake()
    {
        roomInfoText = GetComponentInChildren<TMP_Text>();
        photonManager = GameObject.Find("PhotonManager").GetComponent<PhotonManager>();
    }

    void OnEnterRoom(string roomName)
    {
        // 유저명 설정
        photonManager.SetUserId();
        // 룸 접속
        PhotonNetwork.JoinRoom(roomName);
    }
}