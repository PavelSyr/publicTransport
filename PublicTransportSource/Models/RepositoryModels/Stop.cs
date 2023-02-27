using System.Xml.Serialization;

namespace PublicTransportSource.Models.RepositoryModels;

public class Stop
{
    public bool Forward { get; set; }
    public bool HasBoard { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string? Name { get; set; }
    [XmlElement("Routes")]
    public List<string> Routes { get; set; } = new();
    public string? StopId { get; set; }
    public string? Type { get; set; }
    public bool Virtual { get; set; }
}