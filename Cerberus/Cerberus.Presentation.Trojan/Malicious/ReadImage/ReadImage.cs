using System;
using System.Drawing;
using System.IO;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        // Leitura do JSON
        // troque  --> imagem.json <--- pelo o nome do arquivo, ele pega por padrão no mesmo lugar que foi criado o executavel, mas isso se resolve colocando o caminho do arquivo inteiro
        // só fazer uma pequena alteração XD XD XD
        string jsonString = File.ReadAllText("imagem.json");
        JObject json = JObject.Parse(jsonString);

        // Extraindo as propriedades do JSON
        int altura = (int)json["altura"];
        int largura = (int)json["largura"];
        JArray pixels = (JArray)json["pixels"];
        int profundidade = (int)json["profundidade"];  // Neste caso, é sempre 4 (RGBA)

        // Criando o bitmap
        Bitmap bmp = new Bitmap(largura, altura);

        // Preenchendo os pixels no bitmap
        int index = 0;
        for (int y = 0; y < altura; y++)
        {
            for (int x = 0; x < largura; x++)
            {
                if (index + 3 < pixels.Count)
                {
                    int r = (int)pixels[index];
                    int g = (int)pixels[index + 1];
                    int b = (int)pixels[index + 2];
                    int a = (int)pixels[index + 3];  // Transparência (alfa)
                    Color color = Color.FromArgb(a, r, g, b);
                    bmp.SetPixel(x, y, color);
                    index += 4;
                }
            }
        }

        // Salvando a imagem em formato PNG
        bmp.Save("imagem.png", System.Drawing.Imaging.ImageFormat.Png);

        Console.WriteLine("Imagem PNG criada com sucesso!");
    }
}
