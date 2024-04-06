# Use the latest Node.js LTS version as a base image
FROM node:latest AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
EXPOSE 3000
CMD ["npm", "start"]
