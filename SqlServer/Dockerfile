FROM mcr.microsoft.com/mssql/server:2017-latest-ubuntu

ENV SA_PASSWORD z28KH6y^=LF$)UxQ
ENV ACCEPT_EULA Y
ENV MSSQL_PID Express

EXPOSE 1433

RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app
COPY . /usr/src/app
RUN chmod +x /usr/src/app/run-initialization.sh

CMD /bin/bash ./entrypoint.sh
