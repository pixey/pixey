REM Get repository directory
SET script_path=%~dp0
SET script_path=%script_path:~0,-1%

REM Run docs build using docker
docker run --rm -it -p 8001:8000 -v %script_path%:/docs squidfunk/mkdocs-material