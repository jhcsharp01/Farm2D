using UnityEngine;
using System.Collections;
using Assets.Scripts.InventorySystem;



public class Player : MonoBehaviour
{
    public Inventory Inventory;

    private void Awake()
    {
        //기본 인벤토리 4개 제공
        Inventory = new Inventory(4);
    }

    public void Drop(Harvest harvest)
    {
        //위치 설정
        var spawn = transform.position;

        //던지는 범위
        float x = 5.0f;
        
        Vector3 offset = new Vector3(x, 0, 0);

        //오브젝트 생성
        var go = Instantiate(harvest, spawn + offset, Quaternion.identity);
        //오브젝트에 대한 물리적인 힘 작용
        //go.rbody.AddForce(offset * 2f, ForceMode2D.Impulse);

    }
}
