using System.Collections.Generic;

namespace PlayerInput
{
    public interface ISelectionInteractor
    {
        public List<MapObjectType> GetValidSelectables();
        public void ProcessInteraction(ISelectable selectable);
    }
}
