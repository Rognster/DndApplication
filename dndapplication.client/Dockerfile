# Use an official Node.js runtime as a parent image
FROM node:20-alpine

# Set the working directory in the container
WORKDIR /app

# Copy the package.json and package-lock.json files to the container
COPY package*.json ./

# Install the dependencies
RUN npm install

# Copy the rest of the application code to the container
COPY . .

# Add debugging step to check Vite configuration
RUN node -e "console.log(require('./vite.config.ts'))"

# Build the application
RUN npm run build

# Expose the port the app runs on
EXPOSE 8080

# Define the command to run the app
CMD ["npm", "run", "serve"]