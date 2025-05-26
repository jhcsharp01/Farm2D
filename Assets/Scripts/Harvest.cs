using Assets.Scripts.Items;
using UnityEngine;


public enum CollectType
{
    None, SEED
}


public class Harvest : MonoBehaviour
{
    public CollectType type;
    public Sprite icon; //�̹��� ���

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //1. �±� ����
        if(collision.CompareTag("Player"))
        {
            //2. �÷��̾� Ŭ���� Ȯ��
            var player = collision.GetComponent<Player>();

            var item = GetComponent<Item>();


            if(item != null)
            {
                //3. �÷��̾ ���� �κ��丮�� �߰�
                player.Inventory.Add(item);
                Destroy(gameObject);
            }
        }
    }
}
