using UnityEngine;

public class RayInteractor : MonoBehaviour
{
    private Camera mainCamera;
    private RaycastHit hit;
    public LayerMask interactableLayer;
    public float maxInteractDistance = 5f;
    public GameObject activationObject;
    public GameObject CrossHair;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, maxInteractDistance, interactableLayer))
        {
            ObjectCast interactableObject = hit.collider.GetComponent<ObjectCast>();

            if (interactableObject != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    interactableObject.Interact();
                }

                if (activationObject != null)
                {
                    activationObject.SetActive(true);
                    CrossHair.SetActive(false);
                }
            }
        }
        else
        {
            if (activationObject != null)
            {
                activationObject.SetActive(false);
                CrossHair.SetActive(true);
            }
        }
    }
}
