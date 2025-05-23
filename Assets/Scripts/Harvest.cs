using UnityEngine;


public enum CollectType
{
    None, SEED
}


public class Harvest : MonoBehaviour
{
    public CollectType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //1. �±� ����
        if(collision.CompareTag("Player"))
        {
            //var player = collision.GetComponent<PlayerMovement>();
            //player.stat.count_of_harvest++;  

            //2. �÷��̾� Ŭ���� Ȯ��
            var player = collision.GetComponent<Player>();
            //3. �÷��̾ ���� �κ��丮�� �߰�
            player.Inventory.Add(type);        
            Destroy(gameObject);
        }
    }
}
