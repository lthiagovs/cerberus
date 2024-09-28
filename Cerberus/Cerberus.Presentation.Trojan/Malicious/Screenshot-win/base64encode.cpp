#include "base64encode.h"

// Definição da função Base64Encode
std::string Base64Encode(const std::vector<BYTE>& data) {
    static const char* base64_chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                                      "abcdefghijklmnopqrstuvwxyz"
                                      "0123456789+/";
    std::string encoded_data;
    size_t i = 0;
    int val = 0, valb = -6;
    for (size_t idx = 0; idx < data.size(); idx++) {
        val = (val << 8) + data[idx];
        valb += 8;
        while (valb >= 0) {
            encoded_data.push_back(base64_chars[(val >> valb) & 0x3F]);
            valb -= 6;
        }
    }
    if (valb > -6) {
        encoded_data.push_back(base64_chars[((val << 8) >> (valb + 8)) & 0x3F]);
    }
    while (encoded_data.size() % 4) {
        encoded_data.push_back('=');
    }
    return encoded_data;
}

