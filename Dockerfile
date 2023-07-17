FROM node:18-alpine as node
WORKDIR /usr/src/app/front
COPY ./front/package*.json ./

RUN npm install

EXPOSE 3000

CMD [ "npm", "run", "dev" ]