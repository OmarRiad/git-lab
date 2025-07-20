FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY . .

ENTRYPOINT ["sh", "-c", "\
  exe_file_name=$(ls *.exe | head -n1); \
  app_name=${exe_file_name%.exe}; \
  dotnet \"$app_name.dll\" \
"]
