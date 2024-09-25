### Começando

### Configuração do Ambiente de Desenvolvimento
- Crie um novo projeto:

```sh
     dotnet new webapi --name ...
     add file readme.md
     add file .gitignore
```


 - Instale a ferramenta dotnet-ef:
 - 
```sh

    dotnet tool install --global dotnet-ef
    dotnet tool update --global dotnet-ef
    dotnet tool list --global
```
### Fazendo referencias ao dotenet-ef core:
```sh

    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

## Modelos

Crie modelos no diretório do projeto.
```sh
add file Models no diretorio do projeto.
add class Evento dentro da Models com os seguintes atributos:

 class Evento
    {
        public int EventoId { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public string Tema {get; set; }
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
        public string ImagemUrl { get; set; }
    }

```


## Iniciando o projeto Angular

 - Esse comando exibirá a versão npm atualmente instalada.  
```sh

    npm --version
```
 - Verifique a versão do node instalada com esse comando
```sh

   node -v
```
 - Garanta que a versão 12 do Angular CLI seja instalada e usada no sistema com esse comando.

 ```sh
 npm install -g @angular/cli@12

```

 - Para criar um novo projeto Angular com o nome que deseja colocar no projeto utilize o seguinte comando:
 
 ```sh
ng new ProEventos-App

```

 - Para gerar um componente ng g c (Nome Pasta), execute o seguinte comando no terminal:

 ```sh
ng g c eventos 
ng g c palestrantes

```