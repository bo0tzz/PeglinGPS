using UnityEngine;
using Worldmap;

namespace PeglinGPS
{
    public static class Utils
    {
        public static SpriteRenderer GetSpriteRenderer(MapNode node)
        {
            var num = node.RoomType - RoomType.BATTLE;
            if (num >= 0 && node._icons.Length > num)
                return node._icons[num].GetComponent<SpriteRenderer>();
            return null;
        }

        public static float Get2DDistance(Vector3 click, Vector3 point)
        {
            click.z = point.z;
            return (click - point).magnitude;
        }

        public static void RecolorSlotManagers(SlotManager left, SlotManager right)
        {
            var leftNode = StaticGameData.currentNode.ChildNodes[0];
            var leftSpriteRenderer = GetSpriteRenderer(leftNode);
            left.icon.color = leftSpriteRenderer.color;

            var rightNode = StaticGameData.currentNode.RightChild;
            var rightSpriteRenderer = GetSpriteRenderer(rightNode);
            right.icon.color = rightSpriteRenderer.color;
        }
    }
}