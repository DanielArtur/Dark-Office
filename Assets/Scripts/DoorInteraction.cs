using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteraction
{
    [SerializeField] private Animator animator;

    private bool isOpen;
    public bool IsOpen { get => isOpen; }

    private bool isActionRunning;
    public bool IsActionRunning { get => isActionRunning; }

    public void Interact()
    {
        if (isActionRunning)
            return;

        if (isOpen)
            Close();
        else
            Open();
    }

    private void Open()
    {
        isActionRunning = true;
        animator.SetTrigger("Open");
        AudioManager.Instance.PlayDoorSound();
    }

    public void OpenCompleted()
    {
        isActionRunning = false;
        isOpen = true;
    }

    private void Close()
    {
        isActionRunning = true;
        animator.SetTrigger("Close");
        AudioManager.Instance.PlayDoorSound();
    }

    public void CloseCompleted()
    {
        isActionRunning = false;
        isOpen = false;
    }
}
