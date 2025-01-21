# Use a imagem base do Ubuntu
FROM ubuntu:24.04

# Define o responsável pela imagem (opcional)
LABEL maintainer="mtw.nda@hotmail.com"

#sudo apt install dotnet-sdk-8.0

ENV NVM_DIR ~/.nvm
# /usr/local/nvm 
# or ~/.nvm , depending
ENV NODE_VERSION 18.18.0

# Atualize o sistema e instale dependências básicas
RUN apt-get update && \
    apt-get upgrade -y \
    && apt-get install -y software-properties-common \
    && add-apt-repository ppa:dotnet/backports \
    && apt-get install -y --no-install-recommends \
    curl \
    wget \
    unzip \
    dotnet-sdk-8.0 \
    build-essential \
    && wget https://nodejs.org/dist/v${NODE_VERSION}/node-v${NODE_VERSION}-linux-x64.tar.xz \
    && tar -xJf node-v${NODE_VERSION}-linux-x64.tar.xz -C /usr/local --strip-components=1 \
    && rm node-v${NODE_VERSION}-linux-x64.tar.xz \
    && apt-get purge -y --auto-remove wget xz-utils \
    && rm -rf /var/lib/apt/lists/*

# ENV NODE_PATH $NVM_DIR/v$NODE_VERSION/lib/node_modules
# ENV PATH      $NVM_DIR/v$NODE_VERSION/bin:$PATH

# Configura o diretório de trabalho dentro do container
WORKDIR /app
COPY ./start-all.sh .
COPY ./dotnet/hahn-software-assesment/. /app/backend
COPY ./typescript/hahn-software-assesment/. /app/frontend

WORKDIR /app/backend
RUN dotnet build

WORKDIR /app/frontend
RUN npm install

WORKDIR /app


# Expõe a porta que será usada pela aplicação
EXPOSE 5094 5000 5173

# Define o comando padrão para rodar a aplicação
# Substitua pelo comando específico da sua aplicação
# CMD ["ls", "."]
CMD ["sh", "start-all.sh"]
