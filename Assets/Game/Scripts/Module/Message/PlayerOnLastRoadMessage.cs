using UnityEngine;

namespace Croxxing.Module.Message
{
    public struct PlayerOnLastRoadMessage
    {
        public Vector2 ResetPosition { get; private set; }

        public PlayerOnLastRoadMessage(Vector2 resetPosition)
        {
            ResetPosition = resetPosition;
        }
    }
}
