namespace HomeIoT.Web.Utils;
using HomeIoT.Web.Shared.Component;

public static class CardMetadataExtensions
{
    public static List<CardMetadata> ConvertToCardMetadata<TResponse,TCard>(this IEnumerable<TResponse>? devicesStates)
        {
            if (devicesStates is null)
            {
                return new List<CardMetadata>();
            }

            return devicesStates.Select(x =>
                    new CardMetadata
                    {
                        Name = typeof(TCard).Name,
                        Type = typeof(TCard),
                        Parameters = new()
                            {
                                { typeof(TResponse).Name, x },
                            }
                    }
            ).ToList();
        }
}