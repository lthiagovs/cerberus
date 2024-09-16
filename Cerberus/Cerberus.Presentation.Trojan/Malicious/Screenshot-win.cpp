#include <windows.h>
#include <gdiplus.h>
#include <memory>
#include <iostream>
#include <ostream>
#include <string>
#include <vector>

#pragma comment(lib, "gdiplus.lib")

// Função auxiliar para obter o CLSID do encoder
int GetEncoderClsid(const WCHAR* format, CLSID* pClsid) {
    UINT num = 0;
    UINT size = 0;

    Gdiplus::GetImageEncodersSize(&num, &size);
    if (size == 0) return -1;

    std::vector<BYTE> buffer(size);
    Gdiplus::ImageCodecInfo* pImageCodecInfo = reinterpret_cast<Gdiplus::ImageCodecInfo*>(&buffer[0]);

    Gdiplus::GetImageEncoders(num, size, pImageCodecInfo);

    for (UINT j = 0; j < num; ++j) {
        if (wcscmp(pImageCodecInfo[j].MimeType, format) == 0) {
            *pClsid = pImageCodecInfo[j].Clsid;
            return j;
        }
    }

    return -1;
}

bool CapturaTelaWindows(const std::wstring& nomeArquivo) {
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

        // Salva o bitmap como arquivo PNG
        Gdiplus::Bitmap bitmap(hbmTela, nullptr);
        CLSID encoderClsid;
        if (GetEncoderClsid(L"image/png", &encoderClsid) != -1) {
            bitmap.Save(nomeArquivo.c_str(), &encoderClsid, nullptr);
        }

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
// CapturaTelaWindows(L"screenshot.png");
int main() {
    // Nome do arquivo para salvar a captura de tela
    std::wstring nomeArquivo = L"captura_de_tela.png";

    // Chama a função para capturar a tela
    if (CapturaTelaWindows(nomeArquivo)) {
        std::wcout << L"Captura de tela salva com sucesso como: " << nomeArquivo << std::endl;
    } else {
        std::wcerr << L"Falha ao capturar a tela." << std::endl;
    }

    return 0;
}
