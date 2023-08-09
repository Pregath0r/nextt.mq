using NEXTT.MQTT.Topics;

namespace NEXTT.MQTT.Connection;

public class ConnectionConfig
{
    //General Configs
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? FileName { get; set; }
    public string? MqttClientId { get; set; }
    
    //Connection
    public TransportProtocol? Protocol { get; set; }
    public string? Host { get; set; }
    public int Port { get; set; }
    
    //Security
    public bool TlsEnabled { get; set; }
    public bool ValidateCertificates { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    
    //Topics
    private List<TopicSubscription>? TopicSubscriptions { get; set; }
}