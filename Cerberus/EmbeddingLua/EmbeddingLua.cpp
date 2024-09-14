#include <iostream>
#include <string>


extern "C" {
#include "Lua54/include/lua.h"
#include "Lua54/include/lauxlib.h"
#include "Lua54/include/lualib.h"
}

int main()
{
    std::string cmd = "a = 7+11";

    lua_State* L = luaL_newstate();

    int r = luaL_dostring(L, cmd.c_str());

    return 0;
}
