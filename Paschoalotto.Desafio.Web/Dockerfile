FROM node:lts-alpine
ARG api_url
ENV VITE_API_URL=${api_url}
WORKDIR /usr/src/app
RUN npm install -g pnpm
COPY ["package.json", "pnpm-lock.yaml", "./"]
RUN pnpm install --silent
COPY . .
ENV NODE_ENV=production
RUN pnpm build
EXPOSE 4173
CMD ["pnpm", "preview", "--host"]
