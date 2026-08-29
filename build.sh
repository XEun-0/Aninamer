#!/bin/bash

# Check if release or just build

if [ "$1" = "build" ]; then
    echo "Making build"
    dotnet build
    exit 0
fi

echo "Making release build"
dotnet build -c Release