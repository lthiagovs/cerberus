cmake_minimum_required(VERSION 3.14)

project(screenshot_win)

set(CMAKE_CXX_STANDARD 17)

# inclui biblioteca nlohmann/json via FetchContent
include(FetchContent)

FetchContent_Declare(
  json
  GIT_REPOSITORY https://github.com/nlohmann/json.git
  GIT_TAG v.3.11.2 # versao estavel mais recente
)

FetchContent_MakeAvailable(json)

# Adiciona o executavel do seu projeto
add_executable(screenshot screenshot_winnew)

# linka biblioteca do executavel
target_link_libraries(screenshot_winnew PRIVATE nlohmann_json::nlohmann_json)
