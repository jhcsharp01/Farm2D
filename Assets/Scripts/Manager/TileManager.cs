using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Manager
{
	public class TileManager : MonoBehaviour
	{
		//상호작용 맵에 대한 설정
		[SerializeField] private Tilemap interactables;

		//타일(상호작용 이미지 가리기)
		[SerializeField] private Tile hidden;


        private void Start()
        {
			foreach (var pos in interactables.cellBounds.allPositionsWithin)
			{
				interactables.SetTile(pos, hidden);
			}
        }

    }
}