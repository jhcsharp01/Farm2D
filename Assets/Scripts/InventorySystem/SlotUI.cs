﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.InventorySystem
{
    public class SlotUI : MonoBehaviour
    {
        public Image slot_icon;
        public Text slot_count_text;

        //슬롯 적용
        public void SetSlot(Slot slot)
        {
            if(slot != null)
            {
                slot_icon.sprite = slot.icon;
                slot_count_text.text = slot.count.ToString();
            }
        }
        //빈 슬롯 설정
        public void SetEmpty()
        {
            slot_icon.sprite = null;
            slot_count_text.text = "";
        }

    }
}
