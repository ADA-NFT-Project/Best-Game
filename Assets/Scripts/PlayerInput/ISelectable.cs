using UnityEngine;

namespace PlayerInput
{
    public interface ISelectable
    {
        public void RenderSelection();
        public MapObjectType GetMapObjectType();
    }
}
