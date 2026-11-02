#!/usr/bin/env bash
set -euo pipefail

login='{"email": "visual-regression-tracker@example.com", "password": "123456"}'
token=$(curl -sf -H 'Content-Type: application/json' -d "$login" "$VRT_APIURL/users/login" | jq -r .token)
auth="Authorization: Bearer $token"

project=$(curl -sf -H "$auth" "$VRT_APIURL/projects" | jq -r --arg name "$VRT_PROJECT" '.[] | select(.name == $name or .id == $name) | .id')
build=$(curl -sf -H "$auth" "$VRT_APIURL/builds?projectId=$project&take=1&skip=0" | jq '.data[0]')

# The example must have stopped the build although its test failed.
jq -e '.isRunning == false and .unresolvedCount > 0' <<<"$build"

curl -sf -X PATCH -H "$auth" "$VRT_APIURL/builds/$(jq -r .id <<<"$build")/approve?merge=false"
