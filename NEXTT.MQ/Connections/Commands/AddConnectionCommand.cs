using System;
using System.Windows.Input;
using NEXTT.MQ.Connections.ViewModel;
using NEXTT.MQTT.Connection;

namespace NEXTT.MQ.Connections.Commands;

public class AddConnectionCommand : ICommand
{
    private readonly ConnectionWindowViewModel _viewModel;

    public AddConnectionCommand(ConnectionWindowViewModel viewModel)
    {
        _viewModel = viewModel;
    }
    
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        var newEmptyConnection = new ConnectionConfig()
        {
            Name = "New Connection Config",
            Id = Guid.NewGuid().ToString(),
            Protocol = TransportProtocol.Mqtt,
            TlsEnabled = false,
            ValidateCertificates = true,
            Host = "localhost",
            Port = 1883,
        };
        
        _viewModel.ConnectionConfigs.Add(newEmptyConnection);
    }

    public event EventHandler? CanExecuteChanged;
}