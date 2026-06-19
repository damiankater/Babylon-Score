#!/bin/bash
# Deploy Babylon Score to GitHub — IPA builds automatically via GitHub Actions

echo "=== BABYLON SCORE - GitHub Deploy ==="

read -p "Your GitHub username: " username

cd "$(dirname "$0")"
git add .
git commit -m "Babylon Score update" 2>/dev/null || true
git remote add origin "https://github.com/$username/BabylonScore.git" 2>/dev/null || \
    git remote set-url origin "https://github.com/$username/BabylonScore.git"
git branch -M main
git push -u origin main

echo ""
echo "Pushed! Your IPA will build at:"
echo "https://github.com/$username/BabylonScore/actions"
echo "Download the artifact after ~5 min and rename to .ipa"
