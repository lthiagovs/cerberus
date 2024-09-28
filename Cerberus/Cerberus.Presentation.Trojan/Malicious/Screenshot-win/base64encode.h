#ifndef BASE64_H
#define BASE64_H

#include <vector>
#include <string>

// Definindo BYTE caso não esteja declarado
#ifndef BYTE
typedef unsigned char BYTE;
#endif

// Declaração da função para converter bytes da imagem para base64
std::string Base64Encode(const std::vector<BYTE>& data);

#endif // BASE64_H

