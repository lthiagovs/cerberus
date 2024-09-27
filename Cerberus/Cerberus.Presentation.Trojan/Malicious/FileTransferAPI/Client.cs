using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class FileTransferClient
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        Console.WriteLine("1. Listar Diretório");
        Console.WriteLine("2. Fazer Upload");
        Console.WriteLine("3. Fazer Download");
        Console.Write("Escolha uma opção: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await ListDirectory();
                break;
            case "2":
                await UploadFile();
                break;
            case "3":
                await DownloadFile();
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    private static async Task ListDirectory()
    {
        Console.Write("Digite o caminho do diretório: ");
        var path = Console.ReadLine();

        var response = await client.GetAsync($"http://localhost:5000/api/file/list?path={path}");
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
    }

    private static async Task UploadFile()
    {
        Console.Write("Digite o caminho do arquivo para upload: ");
        var filePath = Console.ReadLine();

        using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        using var content = new StreamContent(fileStream);

        var form = new MultipartFormDataContent();
        form.Add(content, "file", Path.GetFileName(filePath));

        var response = await client.PostAsync("http://localhost:5000/api/file/upload", form);
        var responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseContent);
    }

    private static async Task DownloadFile()
    {
        Console.Write("Digite o caminho do arquivo para download: ");
        var filePath = Console.ReadLine();

        var response = await client.GetAsync($"http://localhost:5000/api/file/download?filePath={filePath}");
        var fileBytes = await response.Content.ReadAsByteArrayAsync();

        var fileName = Path.GetFileName(filePath);
        await System.IO.File.WriteAllBytesAsync(fileName, fileBytes);
        Console.WriteLine($"Arquivo {fileName} baixado com sucesso.");
    }
}

