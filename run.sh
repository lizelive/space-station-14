#!/bin/sh

dotnet run --property WarningLevel=0 --project Content.Server

dotnet run --project Content.Client -- --connect