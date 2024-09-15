#include "pch.h"
#include "keys.h"
#include <conio.h>

int getPressedKey() {
	return _getch();
}

const char* convertToChar(int key) {
	return reinterpret_cast<const char*>(&key);
}