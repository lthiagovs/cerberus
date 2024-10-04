#include <windows.h>
#include <gdiplus.h>
#include <memory>
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <json/json.h>  // Biblioteca para lidar com JSON
#pragma comment(lib, "gdiplus.lib")

// Função para capturar os dados de pixels da tela
bool CapturaTelaWindows(const std::string& nomeArquivoJson) {
    // Inicializa GDI+
    Gdiplus::GdiplusStartupInput gdiplusStartupInput;
    ULONG_PTR gdiplusToken;
    Gdiplus::GdiplusStartup(&gdiplusToken, &gdiplusStartupInput, nullptr);

    {
        // Obtém as dimensões da tela
        int larguraTela = GetSystemMetrics(SM_CXSCREEN);
        int alturaTela = GetSystemMetrics(SM_CYSCREEN);

        // Cria um DC compatível com a tela
        HDC hdcTela = GetDC(nullptr);
        HDC hdcMemDC = CreateCompatibleDC(hdcTela);
        HBITMAP hbmTela = CreateCompatibleBitmap(hdcTela, larguraTela, alturaTela);
        HBITMAP hbmAntigo = static_cast<HBITMAP>(SelectObject(hdcMemDC, hbmTela));

        // Copia a tela para o bitmap
        BitBlt(hdcMemDC, 0, 0, larguraTela, alturaTela, hdcTela, 0, 0, SRCCOPY);

        // Obtenha os dados de pixel
        BITMAP bmpTela;
        GetObject(hbmTela, sizeof(BITMAP), &bmpTela);

        int largura = bmpTela.bmWidth;
        int altura = bmpTela.bmHeight;
        int profundidade = bmpTela.bmBitsPixel / 8;  // Bytes por pixel

        std::vector<BYTE> buffer(altura * bmpTela.bmWidthBytes);
        GetBitmapBits(hbmTela, buffer.size(), &buffer[0]);

        // Cria o objeto JSON
        Json::Value jsonRaiz;
        jsonRaiz["largura"] = largura;
        jsonRaiz["altura"] = altura;
        jsonRaiz["profundidade"] = profundidade;

        // Adiciona os dados de pixel como uma lista de inteiros
        for (size_t i = 0; i < buffer.size(); ++i) {
            jsonRaiz["pixels"].append(buffer[i]);
        }

        // Salva o arquivo JSON
        std::ofstream arquivoJson(nomeArquivoJson);
        arquivoJson << jsonRaiz;
        arquivoJson.close();

        // Limpa
        SelectObject(hdcMemDC, hbmAntigo);
        DeleteObject(hbmTela);
        DeleteDC(hdcMemDC);
        ReleaseDC(nullptr, hdcTela);
    }

    // Encerra GDI+
    Gdiplus::GdiplusShutdown(gdiplusToken);

    return true;
}

// Exemplo de uso:
int main() {
    // Nome do arquivo JSON para salvar os dados da captura de tela
    std::string nomeArquivoJson = "captura_de_tela.json";

    // Chama a função para capturar a tela
    if (CapturaTelaWindows(nomeArquivoJson)) {
        std::cout << "Captura de tela salva com sucesso como: " << nomeArquivoJson << std::endl;
    }
    else {
        std::cerr << "Falha ao capturar a tela." << std::endl;
    }

    return 0;
}
