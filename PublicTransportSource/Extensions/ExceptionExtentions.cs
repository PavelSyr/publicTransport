namespace PublicTransportSource.Extensions;

public static class ExceptionExtentions
{
    public static List<string> GetAllErrors(this Exception ex)
    {
        var messages = new List<string>();

        var innerEx = ex;
        while (innerEx != null)
        {
            messages.Add(innerEx.Message);

            innerEx = innerEx.InnerException;
        }

        return messages;
    }
}