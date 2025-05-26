using System;
using UnityEngine;

[Serializable]
public class PlayerStat
{
    public float speed;          //�÷��̾��� �̵� �ӵ�
    //public int count_of_harvest; //���� ��Ȯ���� ����
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerStat stat;
    Animator animator;

   

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }
    public Vector2 last = Vector2.down;
    void SetAnimateMovement(Vector3 direction)
    {
        if(animator != null)
        {

            //magnitude : ������ ����
            //x,y,z�� ���� ������ ������ ���� ��Ʈ ��
            if(direction.magnitude > 0)
            {
                animator.SetBool("IsMove", true);
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);

                last = direction.normalized;   
            }
            else
            {
                animator.SetBool("IsMove", false);
                animator.SetFloat("horizontal", last.x);
                animator.SetFloat("vertical", last.y);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector2(h, v);
        SetAnimateMovement(dir);
        transform.position += dir * stat.speed * Time.deltaTime;
    }
}
