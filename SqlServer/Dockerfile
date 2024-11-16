FROM mcr.microsoft.com/mssql/server:2017-latest-ubuntu

ENV SA_PASSWORD z28KH6y^=LF$)UxQ
ENV ACCEPT_EULA Y
ENV MSSQL_PID Express

EXPOSE 1433

RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app
COPY . /usr/src/app
RUN chmod +x /usr/src/app/run-initialization.sh

# Create non-root user and set permissions
RUN (which useradd || apt-get update && apt-get install -y useradd) && \
    (useradd -u 1000 appuser || true) && \
    (chown -R 1000:1000 /usr/src/app)

# Switch to non-root user
USER 1000

CMD /bin/bash ./entrypoint.sh
