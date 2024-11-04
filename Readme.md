# ProEventosApp
Este projeto foi gerado com Angular CLI versão 12.2.18.

## Servidor de Desenvolvimento 
Execute ng serve para iniciar um servidor de desenvolvimento. Navegue para http://localhost:4200/. O aplicativo será recarregado automaticamente se você modificar qualquer um dos arquivos de origem.

# 🔧 Configuração do Ambiente de Desenvolvimento

- Execute os seguintes comandos para instalar e atualizar a ferramenta dotnet-ef:

- Configuração do Ambiente de Desenvolvimento
- Crie um novo projeto:
    ```sh
     dotnet new webapi --name ...
     add file readme.md
     add file .gitignore
    ```    
- Instale a ferramenta dotnet-ef:
    ```sh
    dotnet tool install --global dotnet-ef
    dotnet tool update --global dotnet-ef
    dotnet tool list --global  
    ```
    
- Fazendo referencias ao dotenet-ef core:
    ```sh
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    ```
    
## Modelos 
**Crie modelos no diretório do projeto.**

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


## 📦 Iniciando o projeto Angular ##
 
* Esse comando exibirá a versão npm atualmente instalada.
    ```sh
     npm --version 
    ```  
* Esse comando exibirá a versão npm atualmente instalada.
     ```sh
     node -v
     ``` 
Verifique a versão do node instalada com esse comando.
   
**Garanta que a versão 12 do Angular CLI seja instalada e usada no  sistema com esse comando.**
  
      npm install -g @angular/cli@1      

**Para criar um novo projeto Angular com o nome que deseja colocar no projeto utilize o seguinte comando:**

```sh
ng new ProEventos-App
```

## 🚀 Criação de Componentes  

No Angular, você pode gerar componentes usando o comando `ng generate` ou sua forma abreviada `ng g`. Aqui estão alguns exemplos de como criar componentes específicos no seu projeto:

#### Comandos para Criar Componentes

1. **Gerar o Componente de Eventos**
   ```bash
   ng g c eventos
   ng g c palestrantes
   ng g c nav
   ```

### 🛠️ Compilação do Projeto 

Para compilar o projeto Angular, execute o seguinte comando:

```bash
ng build
```

## 🧪 Executando Testes Unitários 

Para rodar os testes unitários do projeto, execute o seguinte comando:

```bash
ng test
```

## Executando Testes End-to-End.

Para rodar os testes end-to-end do projeto, utilize o seguinte comando:

```sh
    ng e2e
```

*Essa formatação inclui um título claro, uma descrição concisa e o comando a ser executado, proporcionando uma compreensão rápida do que essa seção cobre.*


Este comando irá iniciar o Karma, que é o framework de testes utilizado, e executará todos os testes unitários presentes no projeto. O Karma abrirá uma janela do navegador onde você poderá visualizar os resultados dos testes em tempo real.



### Mais Ajuda

Para obter mais ajuda sobre o Angular CLI, use o comando:
```sh
    ng help
```
ou acesse a página [Visão Geral e Referência de Comandos do Angular CLI](https://angular.io/cli).




## Configurando o HttpClientModule no Angular.
Para permitir que nossa aplicação Angular faça requisições HTTP, precisamos configurar o HttpClientModule. 

Siga os passos abaixo para adicioná-lo corretamente ao seu projeto:

1. Abra o arquivo app.module.ts:

* Esse arquivo é responsável por configurar os módulos que sua aplicação utilizará.

2. Adicione o HttpClientModule nos Imports:
* No bloco de imports dentro do @NgModule, adicione o HttpClientModule. Isso garante que o módulo de requisições HTTP será registrado e estará disponível em toda a aplicação.

- Adicione o seguinte código:

```sh
import { HttpClientModule } from '@angular/common/http';
```
**Caso você já tenha iniciado o import, pode simplesmente usar ```Ctrl +``` no seu editor para completar automaticamente.**

3. Exemplo Completo: Após essas adições, o seu arquivo app.module.ts deve ficar assim:

```sh
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';

// Adicione essa linha para habilitar requisições HTTP
import { HttpClientModule } from '@angular/common/http';

@NgModule({
 declarations: [
   AppComponent
 ],
 imports: [
   BrowserModule,
   // Inclua o HttpClientModule aqui
   HttpClientModule
 ],
 providers: [],
 bootstrap: [AppComponent]
})
export class AppModule { }
```


Agora, seu aplicativo está pronto para fazer requisições HTTP. Qualquer serviço que precise acessar uma API poderá usar o HttpClient para realizar essas operações.

 ## Adicionando Font Awesome e ngx-bootstrap ao Projeto
Para adicionar ícones e componentes de interface com Font Awesome e ngx-bootstrap, digite os seguintes comandos:
 
 ```sh 
 npm install --save @fortawesome/fontawesome-free
 npm install --save ngx-bootstrap
 npm install bootstrap 
 ```

## Adicionando Estilos e Módulos ao Projeto Angular
Para configurar o Bootstrap, o ngx-bootstrap, e o Font Awesome, além de habilitar animações no Angular, siga os passos abaixo:

1.  Adicionar Estilos ao styles.scss Abra o arquivo styles.scss e adicione as seguintes importações:

```sh
  @import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
  @import '../node_modules/ngx-bootstrap/datepicker/bs-datepicker.css';
  @import '../node_modules/@fortawesome/fontawesome-free/css/all.min.css';
  ```
Essas importações irão garantir que os estilos do Bootstrap, ngx-bootstrap e Font Awesome estejam disponíveis globalmente em seu projeto Angular.

Abra o arquivo app.module.ts e adicione o BrowserAnimationsModule ao seu imports.

No topo do arquivo app.module.ts, adicione o seguinte import:

  ```sh
  import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
  ```

# Tive um erro com o [(ngModel)]
**E consegui resolver da seguinte forma.**

Ao utilizar o ```[(ngModel)]```, encontrei o erro:

  ```sh 
  Property 'ɵunwrapWritableSignal' does not exist on type 'typeof 
  import("c:/Projetos/PROEVENTOS/Front/ProEventos-App/node_modules/@angular/core/core")'.ngtsc(2339)
  ```
Esse erro aconteceu no template do componente EventosComponent. A solução foi instalar a versão 17.1.1 do Angular Language Service, que corrige o problema.

Execute o seguinte comando para instalar a versão correta:

 ```sh
 npm install @angular/language-service@17.1.1 
 ```
Para mais detalhes, consultei a discussão sobre esse erro neste link.


## Instruções para configurar uma aplicação modular com camadas de Persistência, Domínio e Aplicação, usando os comandos abaixo.

**Criando uma Nova Solução e Projetos com .NET**

Para iniciar um novo projeto .NET e configurar a solução do seu projeto, siga as instruções abaixo.

**Comando Básico:**

```sh 
dotnet new
```
O comando permite criar novos projetos ou arquivos específicos com base em modelos predefinidos. Para listar todos os templates disponíveis para criação de projetos, use o seguinte comando:

```sh 
dotnet new -h 
```
Isso exibirá uma lista de templates que podem ser utilizados para criar soluções, bibliotecas de classes, APIs, e muito mais.


## Criando uma Nova Solução

Para criar uma nova solução (que agrupa múltiplos projetos em um único ambiente de trabalho), execute o seguinte comando:

```sh
 dotnet new sln -n ProEventos

```

* sln: Este parâmetro indica que você está criando uma solução.
* -n ProEventos: Define o nome da solução como ProEventos.

## Criando Projetos Dentro da Solução

Após criar a solução, você pode adicionar diferentes projetos para organizá-la em camadas. Por exemplo:

Para criar um projeto de biblioteca de classes para a camada de persistência:

```sh 
dotnet new classlib -n ProEventos.Persistence
```
Para criar a camada de domínio:

```sh 
dotnet new classlib -n ProEventos.Domain
```

Para criar a camada de aplicação:

```sh
dotnet new classlib -n ProEventos.Application 
``` 

Adicionando Projetos à Solução

Depois de criar os projetos, adicione-os à solução criada anteriormente usando o comando:

```sh
dotnet sln ProEventos.sln add ./ProEventos.Persistence/ProEventos.Persistence.csproj
dotnet sln ProEventos.sln add ./ProEventos.Domain/ProEventos.Domain.csproj
dotnet sln ProEventos.sln add ./ProEventos.Application/ProEventos.Application.csproj
```
Isso adiciona os projetos à solução, garantindo que eles estejam agrupados corretamente.

Restaurando e Compilando a Solução Após adicionar os projetos à solução, você pode restaurar as dependências e compilar a solução usando os comandos:

```sh 
dotnet restore
dotnet build
```



## Migrações com Entity Framework Core
Este projeto utiliza o Entity Framework Core para gerenciar o banco de dados. O Entity Framework permite que as mudanças no modelo de dados (as classes) sejam refletidas no banco de dados por meio de migrações.

## Criando uma Migração
Sempre que houver mudanças no modelo de dados, como a criação de novas entidades ou modificações nas existentes, você precisará gerar uma nova migração.

Para criar uma migração, siga os passos abaixo:

1. Certifique-se de estar no diretório raiz do projeto, onde a solução (.sln) está localizada.

2. Execute o seguinte comando:

```sh
dotnet ef migrations add <NomeDaMigração> -p ProEventos.Persistence -s ProEventos.API
```

Aplicando a Migração ao Banco de Dados Depois de criar uma migração, você precisa aplicá-la ao banco de dados. Para isso, execute o comando abaixo:

```sh 
dotnet ef database update -p ProEventos.Persistence -s ProEventos.API
```

Isso garantirá que o banco de dados seja atualizado de acordo com as mudanças descritas na migração.

Exemplo Se você estiver criando a primeira migração, chamada Initial, o comando será:

```sh 
dotnet ef migrations add Initial -p ProEventos.Persistence -s ProEventos.API
```
E, para aplicar as mudanças no banco de dados:

```sh 
dotnet ef database update -p ProEventos.Persistence -s ProEventos.API
```

## Instruções Adicionais para Configurar o Entity Framework Core
**Adicionando Referências Necessárias**

Certifique-se de que o arquivo .csproj do projeto de persistência (ProEventos.Persistence) contenha a seguinte referência para usar as ferramentas do Entity Framework Core:

```sh
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.0.2" />
```


Isso adiciona as ferramentas necessárias para que você possa usar os comandos de migração e de atualização do banco de dados.

Restaurando Dependências Depois de adicionar ou atualizar as referências de pacotes no arquivo .csproj, execute o seguinte comando para restaurar as dependências do projeto:

```sh
dotnet restore
````

Esse comando baixa e instala todos os pacotes necessários definidos no projeto.

## Documentação da API com Swagger e XML

Este guia descreve como configurar o Swagger e a geração de arquivos de documentação XML para APIs .NET. Isso permite que você visualize as rotas e endpoints diretamente pelo navegador, facilitando a documentação e o consumo da API.

### 1. Instalação do Swagger
Para adicionar o Swagger ao seu projeto .NET, execute o comando abaixo:

```sh 
dotnet add package Swashbuckle.AspNetCore
```

### 2. Configuração do Swagger no Startup.cs
1. No método ConfigureServices, adicione o Swagger e defina as informações básicas da API:


```sh
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ProEventosContext>(context =>
        context.UseSqlite(Configuration.GetConnectionString("Default"))
    );
    services.AddControllers();
    services.AddCors();

    // Configuração do Swagger
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "SistemaCursoDistancia.Api",
            Version = "v1",
            Description = "API desenvolvida para o site do sistema curso a distância.",
            TermsOfService = new Uri("https://meusite.com"),
            Contact = new OpenApiContact
            {
                Name = "Victor Sérgio",
                Url = new Uri("https://meusite.com")
            },
            License = new OpenApiLicense
            {
                Name = "Curso a distância ApTech",
                Url = new Uri("https://meusite.com")
            }
        });

        // Configuração para incluir XML de documentação
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    });
}
```
2. No método Configure, ative o Swagger apenas para o ambiente de desenvolvimento:

```sh
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
    }

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthorization();

    app.UseCors(x => x.AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowAnyOrigin());

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```

3. Configuração de Comentários XML no .csproj
```sh
<PropertyGroup>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
</PropertyGroup>
```
**Observação: O parâmetro $(NoWarn);1591 evita avisos sobre a ausência de comentários de documentação.** 

4. Adicionando Comentários XML nos Controllers e Métodos

Para documentar seus endpoints, utilize comentários XML sobre os métodos e classes. Abaixo está um exemplo de como documentar um método:

```sh
/// <summary>
/// Retorna todos os eventos.
/// </summary>
/// <returns>Lista de eventos.</returns>

[HttpGet]
public async Task<IActionResult> Get()
{
    // Implementação do método
}
```
## Angular - Organizar,Rotas, Alertas e +.

 - ### Configuração de Interfaces para Modelos no Front-end 1 e 2

1. Criação da Pasta Models
No projeto `ProEventos.App`, criei uma pasta chamada `Models` para organizar as interfaces que representam os modelos de dados.

2. Geração das Interfaces
Dentro da pasta `Models`, gerei as interfaces necessárias usando o Angular CLI:

```sh
ng g i Models/Evento
ng g i Models/Lote
ng g i Models/Palestrante
ng g i Models/Palestrante
ng g i Models/RedeSocial
```
Esse comando cria as interfaces `Evento`, `Lote`, `Palestrante`, `PalestranteEventos` e `RedeSocial` no diretório `Models`.

3. Cópia dos Campos do Back-end
Acessei o projeto de back-end `(ProEventos.API)` e copiei os campos das entidades `Evento`, `Lote`, `Palestrante`, `PalestranteEventos` e `RedeSocial` para suas respectivas interfaces no front-end.



