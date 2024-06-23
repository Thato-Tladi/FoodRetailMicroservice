# Food Retail Microservice

Food retail microservice for minieconomy.

## Getting Started

Follow these instructions to get a copy of the project running on your local machine for development and testing purposes.

### Prerequisites

Before you begin, ensure you have the following installed:
- Docker
- Node.js
- npm

### Installation

Follow these steps to set up your local development environment:

#### Starting the Database

1. Navigate to the Database directory that contains the `docker-compose.yml` file:
    ```bash
    cd Database/
    ```
2. Start the database using Docker Compose:
    ```bash
    docker-compose up
    ```
   Wait for the database to fully initialize and listen for connections.

 #### Stopping the Database

To stop the database containers created by `docker-compose up`, use the following command:

```bash
docker-compose down
```

To delete the database volumes created with the above command and start from fresh, use:
```bash
docker volume rm database_mssql_data
```

#### Starting the Frontend

After setting up the database:
1. Navigate to the frontend directory:
    ```bash
    cd Frontend/
    ```
2. Install the necessary packages:
    ```bash
    npm install
    ```
3. Start the frontend service:
    ```bash
    npm run start
    ```
   Access the frontend by navigating to `http://localhost:3000` in your web browser.
