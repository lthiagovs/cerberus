#include <windows.h>
#include <gdiplus.h>
#include <memory>
#include <iostream>
#include <string>
#include <vector>
#include <sstream>
#include <iomanip>
#include <json/json.h>  // Biblioteca JSON (certifique-se de que você tenha a biblioteca instalada)
#include "base64.h"      // Incluir o cabeçalho da biblioteca Base64

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

bool CapturaTelaWindows(std::string& jsonString) {
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

        // Converte o bitmap para um stream de bytes
        Gdiplus::Bitmap bitmap(hbmTela, nullptr);
        IStream* stream = nullptr;
        CreateStreamOnHGlobal(NULL, TRUE, &stream);

        CLSID encoderClsid;
        if (GetEncoderClsid(L"image/png", &encoderClsid) != -1) {
            bitmap.Save(stream, &encoderClsid, nullptr);
        }

        // Move o ponteiro do stream para o início
        LARGE_INTEGER liZero = {};
        stream->Seek(liZero, STREAM_SEEK_SET, nullptr);

        // Copia os dados do stream para um buffer
        STATSTG statstg;
        stream->Stat(&statstg, STATFLAG_NONAME);
        std::vector<BYTE> buffer(statstg.cbSize.LowPart);
        ULONG bytesRead;
        stream->Read(buffer.data(), buffer.size(), &bytesRead);

        // Converte o buffer para base64
        std::string base64Image = Base64Encode(buffer);

        // Gera o JSON
        Json::Value jsonData;
        jsonData["image_base64"] = base64Image;
        jsonData["format"] = "png";

        // Converte o JSON para string
        Json::StreamWriterBuilder writer;
        jsonString = Json::writeString(writer, jsonData);

        // Limpa
        stream->Release();
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
    // String para armazenar o JSON gerado
    std::string jsonString;

    // Chama a função para capturar a tela e gerar o JSON
    if (CapturaTelaWindows(jsonString)) {
        std::cout << "Dados da captura de tela em JSON: \n" << jsonString << std::endl;
    } else {
        std::cerr << "Falha ao capturar a tela." << std::endl;
    }

    return 0;
}

