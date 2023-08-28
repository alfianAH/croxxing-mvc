using UnityEngine;

namespace Croxxing.Module.Message
{
    public struct PlayerMovementMessage
    {
        public Vector2 InputAxis { get; private set; }

        public PlayerMovementMessage(Vector2 inputAxis)
        {
            InputAxis = inputAxis;
        }
    }
}