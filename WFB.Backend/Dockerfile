FROM amd64/ubuntu:22.10
WORKDIR /usr/local/sbin

RUN echo "deb http://security.ubuntu.com/ubuntu focal-security main" | tee /etc/apt/sources.list.d/focal-security.list
RUN apt update && apt upgrade && apt-get install wget libssl1.1 -y
RUN wget -O wagi.tar.gz https://github.com/deislabs/wagi/releases/download/v0.8.1/wagi-v0.8.1-linux-amd64.tar.gz
RUN tar -xf wagi.tar.gz wagi