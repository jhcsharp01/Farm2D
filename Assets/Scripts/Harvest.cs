using UnityEngine;


public enum CollectType
{
    None, SEED
}


public class Harvest : MonoBehaviour
{
    public CollectType type;
    public Sprite icon; //이미지 등록

    //public 기능을 쓰면서 에디터에서는 보이지 않게 처리
    [HideInInspector] public Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //1. 태그 조사
        if(collision.CompareTag("Player"))
        {
            //2. 플레이어 클래스 확인
            var player = collision.GetComponent<Player>();
            //3. 플레이어가 가진 인벤토리에 추가
            player.Inventory.Add(this);        
            Destroy(gameObject);
        }
    }
}
