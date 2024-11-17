using Renci.SshNet;

namespace SSH.S
{
    public class SshService
    {
        public string RunCommand(string host, string username, string password, string command)
        {
            using (var client = new SshClient(host, username, password))
            {
                try
                {
                    // Подключение к SSH серверу
                    client.Connect();

                    if (client.IsConnected)
                    {
                        Console.WriteLine("Подключено к SSH-серверу.");

                        // Выполнение команды на удаленном сервере
                        var result = client.RunCommand(command);
                        return result.Result;
                    }
                    else
                    {
                        Console.WriteLine("Не удалось подключиться к SSH-серверу.");
                        throw new Exception("Не удалось подключиться.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при выполнении команды: {ex.Message}");
                    return $"Ошибка при выполнении команды: {ex.Message}";
                }
                finally
                {
                    client.Disconnect(); // Отключение после завершения работы
                }
            }
        }
    }
}