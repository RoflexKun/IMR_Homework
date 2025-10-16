using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowOnTrigger : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    private bool isGrabbed = false;
    private XRBaseInteractor interactor;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        interactor = args.interactorObject as XRBaseInteractor;
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        isGrabbed = false;
        interactor = null;
    }

    void Update()
    {
        if (isGrabbed && Input.GetMouseButtonDown(0)) // Left Mouse Button
        {
            // Calculate throw direction before releasing
            Vector3 throwDirection = interactor != null ? interactor.transform.forward : transform.forward;
            float throwForce = 1000f; // You can adjust this value for stronger/weaker throws

            // Release the object
            grabInteractable.interactionManager.SelectExit(
                interactor as IXRSelectInteractor,
                grabInteractable as IXRSelectInteractable
            );

            // Throw logic: apply a strong forward force
            if (rb != null)
            {
                rb.AddForce(throwDirection * throwForce);
            }
        }
    }
}
