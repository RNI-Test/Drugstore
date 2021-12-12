# syntax=docker/dockerfile:1

FROM node:15.14.0-alpine AS frontBuild
WORKDIR /src
COPY ./files/install-dependencies.sh .
ARG FRONTEND_APP_SRC_URL=https://github.com/RNI-Test/DrugstoreFrontend/archive/refs/heads/master.tar.gz
SHELL ["/bin/ash", "-o", "pipefail", "-c"]
RUN chmod +x ./install-dependencies.sh && \
    ./install-dependencies.sh ${FRONTEND_APP_SRC_URL}
COPY ./files/environment.ts.template ./app
COPY ./files/build-app.sh .
ARG PHARMACY_API_URL
RUN chmod +x ./build-app.sh && \
    ./build-app.sh ${PHARMACY_API_URL}

FROM nginx:1.19.8-alpine AS gatewayWithFront
COPY --from=frontBuild /app /usr/share/nginx/html/app
COPY ./files/nginx/nginx.conf /etc/nginx/nginx.conf
COPY ./files/nginx/api_gateway.conf /etc/nginx/api_gateway.conf

FROM nginx:1.19.8-alpine AS gateway
COPY ./files/nginx/nginx.conf /etc/nginx/nginx.conf
COPY ./files/nginx/api_gateway.conf /etc/nginx/api_gateway.conf