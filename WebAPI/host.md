# Deploy/Host config

## App Service
-`minotaurAPI.service`
```ini
[Unit]
Description=Minotaur WebAPI

[Service]
WorkingDirectory=/var/www/minotaurAPI
ExecStart=/usr/bin/dotnet /var/www/minotaurAPI/WebAPI.dll --server.urls="http://*:4455"
Restart=always
# Restart service after 10 seconds if the dotnet service crashes:
RestartSec=10
KillSignal=SIGINT
SyslogIdentifier=minotaur-API
User=www-data
Environment=ASPNETCORE_ENVIRONMENT=Production
Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false

[Install]
WantedBy=multi-user.target

```

## Nginx conf

```conf
server {
    listen        80;
    server_name   minotaurapi.shinobize.com www.minotaurapi.shinobize.com;
    location / {
        proxy_pass         http://localhost:4455;
        proxy_http_version 1.1;
        proxy_set_header   Upgrade $http_upgrade;
        proxy_set_header   Connection keep-alive;
        proxy_set_header   Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
    }
}

```