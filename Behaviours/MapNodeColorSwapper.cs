using UnityEngine;
using Worldmap;

namespace PeglinGPS.Behaviours
{
    public class MapNodeColorSwapper : MonoBehaviour
    {
        public Color color = Color.green;

        private MapNode _node;
        private SpriteRenderer _spriteRenderer;

        private SpriteRenderer SpriteRenderer
        {
            get
            {
                if (_spriteRenderer == null) _spriteRenderer = Utils.GetSpriteRenderer(_node);
                return _spriteRenderer;
            }
        }

        private void OnEnable()
        {
            _node = GetComponent<MapNode>();
        }

        public float Get2DDistance(Vector3 from)
        {
            return Utils.Get2DDistance(from, SpriteRenderer.transform.position);
        }

        public void SwapColor()
        {
            var tmp = SpriteRenderer.color;
            SpriteRenderer.color = color;
            color = tmp;
        }
    }
}