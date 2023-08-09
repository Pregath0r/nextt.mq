using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NEXTT.MQ.Connections.Commands;
using NEXTT.MQTT.Connection;

namespace NEXTT.MQ.Connections.ViewModel;

public class ConnectionWindowViewModel
{

    public List<TransportProtocol> Protocols { get; } = new() { TransportProtocol.Mqtt, TransportProtocol.WebSockets };
    
    public ObservableCollection<ConnectionConfig> ConnectionConfigs { get; set; }
    public ConnectionConfig CurrentConnectionConfig { get; set; } = new() { Name = "New", Id = Guid.NewGuid().ToString()};

    
    public ICommand AddButtonCommand { get; set; }
    
    public ConnectionWindowViewModel()
    {
        ConnectionConfigs = CreateSavedConnectionsList();
        AddButtonCommand = CreateAddButtonCommand();
    }

    private ICommand CreateAddButtonCommand()
    {
        return new AddConnectionCommand(this);
    }

    private ObservableCollection<ConnectionConfig> CreateSavedConnectionsList()
    {
        return new ObservableCollection<ConnectionConfig>()
        {
           new ConnectionConfig()
           {
               Name = "TestConnection",
               Id = Guid.NewGuid().ToString(),
               Host = "localhost",
               Port = 1883,
               Protocol = TransportProtocol.Mqtt
           },
           new ConnectionConfig()
           {
               Name = "TestConnection 222",
               Id = Guid.NewGuid().ToString(),
               Host = "docker.host.internal",
               Port = 8883,
               Protocol = TransportProtocol.WebSockets
           }
        };
    }
}