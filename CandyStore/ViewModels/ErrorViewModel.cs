namespace CandyStore.ViewModels;

public class ErrorViewModel
{
    public string? RequestID { get; set; }
    public string RequestId { get; set; }

    public bool ShowRequestID => !string.IsNullOrEmpty(RequestID);
}