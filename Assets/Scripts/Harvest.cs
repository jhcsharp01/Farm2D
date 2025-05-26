using Assets.Scripts.Items;
using UnityEngine;


public enum CollectType
{
    None, SEED
}


public class Harvest : MonoBehaviour
{
    public CollectType type;
    public Sprite icon; //이미지 등록

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //1. 태그 조사
        if(collision.CompareTag("Player"))
        {
            //2. 플레이어 클래스 확인
            var player = collision.GetComponent<Player>();

            var item = GetComponent<Item>();


            if(item != null)
            {
                //3. 플레이어가 가진 인벤토리에 추가
                player.Inventory.Add(item);
                Destroy(gameObject);
            }
        }
    }
}
