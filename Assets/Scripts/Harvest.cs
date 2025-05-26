using System;
using Assets.Scripts.Items;
using Assets.Scripts.Manager;
using UnityEngine;
//해당 스크립트는 수확물에 관련된 내용들을 관리하는 스크립트입니다.


public enum Grown
{
    Seed, Sprout, Growing, Mature
}

public class Harvest : MonoBehaviour
{
    public Grown grown;
    public Sprite icon; //이미지 등록

    TileManager tileManager;
    public Sprite[] growns;

    public float time = 0;

    private Grown previous = Grown.Seed;

    private void Awake()
    {
        tileManager = GameManager.instance.TileManager;
    }
    private void Update()
    {
        //타일매니저 통해서 좌표 계산 후, 해당 좌표 지점의 타일이 tiles__332가 아니면 작업 안함.
        var tileCellpos = tileManager.Interactables.WorldToCell(transform.position);
        if(tileManager.GetTile(tileCellpos) != "tiles_332")
        {
            return;
        }


        //시간 측정
        time += Time.deltaTime; 

        //일정 시간마다 성장
        if(time >= 1 && (int)grown < 3)
        {
            grown = (Grown)((int)grown + 1); //enum의 1칸 이동
            icon = growns[(int)grown];//변경된 enum의 값으로 아이콘 설정
            time = 0;
        }
        
        //호출 최적화
        if(grown != previous)
        {
            SetHarvest(icon);
            previous = grown;
        }
    }

    private void SetHarvest(Sprite icon)
    {
        GetComponent<SpriteRenderer>().sprite = icon;
    }

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
