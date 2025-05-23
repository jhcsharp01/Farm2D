using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.InventorySystem
{
    public class InventoryUI : MonoBehaviour
    {
        public GameObject inventory; //�κ��丮 â

        public Player player; //�÷��̾� ���

        public List<SlotUI> slots = new List<SlotUI>(); //���� UI ����

        private void Update()
        {
            //��ư ������ �κ��丮 Ű�� ���
            if (Input.GetKeyDown(KeyCode.I))
            {
                OnOFF();
            }
        }

        public void OnOFF()
        {
            SlotRenewal();
            //���� ���ο� ���� true�� false�� �κ��丮�� Ű�ų� ���ϴ�.
            if(inventory.activeSelf)
            {
                inventory.SetActive(false);
                //���� ��� UI�� ���� ���� ����
            }
            else
            {
                inventory.SetActive(true);
            }
        }

        //���Կ� ���� ����
        private void SlotRenewal()
        {
            if (slots.Count == player.Inventory.slots.Count)
            {
                for(int i = 0; i < slots.Count; i++)
                {
                    if (player.Inventory.slots[i].type != CollectType.None)
                    {
                        //���Կ� �̹����� ���� ���� �����Ѵ�.
                        slots[i].SetSlot(player.Inventory.slots[i]);
                    }
                    else
                    {

                        slots[i].SetEmpty();
                    }
                }
            }
        }
    }
}

