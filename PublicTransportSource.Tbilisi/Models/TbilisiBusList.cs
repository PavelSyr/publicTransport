using System.Xml.Serialization;

namespace PublicTransportSource.Tbilisi.Models.RepositoryModels;

[XmlRoot("busList")]
public class TbilisiBusList
{
    [XmlElement("bus")]
    public List<TbilisiBus> Buses { get; set; } = new();
}