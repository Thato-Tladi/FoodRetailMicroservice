#!/bin/bash

# Environment variables should already be set by Docker
echo "Waiting for SQL Server to start..."
SERVER="mssql"  # Use service name from docker-compose.yml

while true; do
  /opt/mssql-tools/bin/sqlcmd -S $SERVER -U sa -P "$SA_PASSWORD" -Q 'SELECT 1' &> /dev/null
  if [ $? -eq 0 ]; then
    echo "SQL Server is up."
    break
  else
    echo "SQL Server is not ready. Waiting..."
    sleep 5
  fi
done

echo "Checking for database..."

# Check if the database exists and create it if it doesn't
/opt/mssql-tools/bin/sqlcmd -S $SERVER -U sa -P "$SA_PASSWORD" -Q "
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'FoodRetailMicroservice')
BEGIN
    CREATE DATABASE [FoodRetailMicroservice];
END
"

echo "Database checked and created if it didn't exist."
