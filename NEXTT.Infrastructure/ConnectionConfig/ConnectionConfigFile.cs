using System.Runtime.InteropServices;
using System.Text.Json;

namespace NEXTT.Infrastructure.ConnectionConfig;

public class ConnectionConfigFile
{
    public static void WriteConnectionConfig(MQTT.Connection.ConnectionConfig connectionConfig)
    {
        var filePath = GetFilePath(connectionConfig);
        if (filePath == null)
        {
            return;
        }

        var content = CreateJsonContent(connectionConfig);
        WriteFileContent(filePath, content);
    }

    private static void WriteFileContent(string filePath, string content)
    {
        File.WriteAllText(filePath, content);
    }

    private static string CreateJsonContent(MQTT.Connection.ConnectionConfig connectionConfig)
    {
        return JsonSerializer.Serialize(connectionConfig);
    }


    private static string? GetFilePath(MQTT.Connection.ConnectionConfig connectionConfig)
    {
        var saveFolder = GetSaveFolder();
        if (saveFolder == null)
        {
            return null;
        }

        CreateSaveFolderIfAbsent(saveFolder);

        var saveFile = CreateSaveFilePath(saveFolder, connectionConfig);
        return saveFile;
    }

    private static string CreateSaveFilePath(string saveFolder, MQTT.Connection.ConnectionConfig connectionConfig)
    {
        return Path.Combine(saveFolder, $"{connectionConfig.FileName}.json");
    }

    private static void CreateSaveFolderIfAbsent(string saveFolder)
    {
        Directory.CreateDirectory(saveFolder);
    }


    private static string? GetSaveFolder()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return GetWindowsSaveFolder();
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return GetLinuxSaveFolder();
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return GetMacOsSaveFolder();
        }

        return null;
    }

    private static string? GetMacOsSaveFolder()
    {
        var saveFolder = "~/Library/Application Support/NEXTT.MQ/Connections";
        return saveFolder;
    }

    private static string? GetLinuxSaveFolder()
    {
        throw new NotImplementedException();
    }

    private static string GetWindowsSaveFolder()
    {
        var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var nexttMqFolder = Path.Combine(appDataFolder, "NEXTT.MQ");
        var connectionsFolder = Path.Combine(nexttMqFolder, "Connections");

        return connectionsFolder;
    }
}