# Dockerfile
FROM node:lts-alpine as build

# create destination directory
WORKDIR /usr/src/nuxt-app


# copy the app, note .dockerignore
COPY package*.json ./
RUN npm install

COPY . /usr/src/nuxt-app/
RUN npm run build
RUN npm run generate

FROM nginx
COPY nginx/default.conf /etc/nginx/conf.d/default.conf
COPY --from=build /usr/src/nuxt-app/dist /usr/share/nginx/html
EXPOSE 80
ENTRYPOINT [ "nginx", "-g", "daemon off;" ]
