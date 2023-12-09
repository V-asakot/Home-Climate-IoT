namespace HomeIoT.Web.Shared.Component
{
    public class CardMetadata
    {
        public string? Name { get; set; }
        public Type Type { get; set; } = null!;
        public Dictionary<string, object?> Parameters { get; set; } = new Dictionary<string, object?>();
    }
}