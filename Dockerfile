# Dockerfile
FROM node:11.13.0-alpine as build

# create destination directory
RUN mkdir -p /usr/src/nuxt-app
WORKDIR /usr/src/nuxt-app

# update and install dependency
RUN apk update && apk upgrade
RUN apk add git

RUN apk add --no-cache --virtual .gyp \
        python \
        make \
        g++ 

# copy the app, note .dockerignore
COPY . /usr/src/nuxt-app/
RUN npm install
RUN npm run build
RUN npm run generate

FROM nginx
COPY nginx/default.conf /etc/nginx/conf.d/default.conf
COPY --from=build /usr/src/nuxt-app/dist /usr/share/nginx/html
EXPOSE 80
ENTRYPOINT [ "nginx", "-g", "daemon off;" ]
