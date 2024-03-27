#!/bin/bash

rootDir="$(cd -P "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"

bash $rootDir/scripts/support/check-dpkg.sh
bash $rootDir/scripts/support/check-jq.sh
bash $rootDir/scripts/support/check-dotnet.sh
bash $rootDir/scripts/support/check-ccr.sh
