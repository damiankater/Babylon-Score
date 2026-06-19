#!/bin/bash
# Quick script to push World Cup 2026 app to GitHub

echo "🌍 World Cup 2026 - GitHub Setup Script"
echo "========================================"

read -p "Enter your GitHub username: " username

if [ -z "$username" ]; then
    echo "❌ Username is required!"
    exit 1
fi

# Initialize git repo
cd "$(dirname "$0")"
git init 2>/dev/null || true
git add .
git commit -m "World Cup 2026 Live Sports App" 2>/dev/null || true

# Add remote
git remote add origin "https://github.com/$username/WorldCup2026.git" 2>/dev/null || \
    git remote set-url origin "https://github.com/$username/WorldCup2026.git"

# Push to main branch
git branch -M main
git push -u origin main

echo ""
echo "✅ Push complete!"
echo "📱 Go to https://github.com/$username/WorldCup2026/actions to download your .ipa"