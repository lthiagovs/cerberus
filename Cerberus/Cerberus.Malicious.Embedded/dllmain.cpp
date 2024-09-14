// dllmain.cpp : Define o ponto de entrada para o aplicativo DLL.
#include "pch.h"

extern "C" {
    #include "Lua54/include/lua.h"
    #include "Lua54/include/lauxlib.h"
    #include "Lua54/include/lualib.h"

    __declspec(dllexport) int hello(lua_State* L) {
        lua_pushnumber(L,24);
        return 1;
    }

    __declspec(dllexport) luaL_Reg Malicious[] = {
        {"hello", hello},  // Mapeia 'testMan' em Lua para a função testMan
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

