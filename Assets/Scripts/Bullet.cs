using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effect;
    // 총알을 발사한 플레이어의 고유번호
    public int actorNumber;

    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000.0f);
        // 일정시간이 지난 후 총알을 삭제
        Destroy(this.gameObject, 3.0f);
    }

    void OnCollisionEnter(Collision coll)
    {
        // 충돌 지점 추출
        var contact = coll.GetContact(0);
        // 충돌 지점에 스파크 이펙트 생성
        var obj = Instantiate(effect,
                              contact.point,
                              Quaternion.LookRotation(-contact.normal));
        Destroy(obj, 2.0f);
        Destroy(this.gameObject);
    }
}
