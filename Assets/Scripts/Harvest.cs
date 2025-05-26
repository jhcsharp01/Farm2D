using UnityEngine;


public enum CollectType
{
    None, SEED
}


public class Harvest : MonoBehaviour
{
    public CollectType type;
    public Sprite icon; //�̹��� ���

    //public ����� ���鼭 �����Ϳ����� ������ �ʰ� ó��
    [HideInInspector] public Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //1. �±� ����
        if(collision.CompareTag("Player"))
        {
            //2. �÷��̾� Ŭ���� Ȯ��
            var player = collision.GetComponent<Player>();
            //3. �÷��̾ ���� �κ��丮�� �߰�
            player.Inventory.Add(this);        
            Destroy(gameObject);
        }
    }
}
