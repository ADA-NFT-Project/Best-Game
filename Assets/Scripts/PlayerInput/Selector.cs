using System;
using UnityEngine;

namespace PlayerInput
{
    public enum MapObjectType
    {
        LanePoint, Ally, Enemy, AllyStruct, EnemyStruct, AllyBase, EnemyBase
    }
    public class Selector : MonoBehaviour
    {
        private ISelectionInteractor activeInteractor;
        private ISelectable selectedObject;

        private Camera cam;
        private Ray selectionRay;

        private void Start()
        {
            cam = Camera.main;
        }

        public void EnableInteractor(ISelectionInteractor interactor)
        {
            activeInteractor = interactor;
        }

        private void Update()
        {
            if (activeInteractor != null)
            {
                SelectorRender();
            }

            if (Input.GetMouseButtonDown(0))
            {
                TryInteract(activeInteractor, selectedObject, cam.ScreenToWorldPoint(Input.mousePosition));
            }
        }

        private void SelectorRender()
        {
            selectionRay = cam.ScreenPointToRay(Input.mousePosition);
            var hits = Physics.RaycastAll(selectionRay);

            foreach (var hit in hits)
            {
                ISelectable selectable = hit.collider.GetComponent<ISelectable>();
                if (selectable == null) continue;
                selectable.RenderSelection();
                selectedObject = selectable;
                return;
            }
        }

        private void TryInteract(ISelectionInteractor interactor, ISelectable selected, Vector3 interactionPoint)
        {
            if (!interactor.GetValidSelectables().Contains(selected.GetMapObjectType())) return;
            interactor.ProcessInteraction(selected);
            activeInteractor = null;
        }

    }
}
