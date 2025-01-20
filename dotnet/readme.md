https://forms.office.com/pages/responsepage.aspx?id=aWfuRqNfg0Se3AwIeOQFmKAdDARcxx9DvfA8cf8b02JUMEMwOExJVkQ4VzNZUkZTR0pETUFNTVBVVS4u&origin=lprLink&route=shorturl


echo fs.inotify.max_user_instances=524288 | sudo tee -a /etc/sysctl.conf && sudo sysctl -p

dotnet tool install --global dotnet-ef

dotnet ef migrations add TesteMigration   - para suportar a migração e criar o conjunto inicial de tabelas para o modelo;

dotnet ef database update - para aplicar a migração ao banco de dados;