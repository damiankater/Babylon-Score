# World Cup 2026 Live Sports App

A FIFA World Cup 2026 themed mobile app for tracking live games and match schedules.

## 🎨 Theme Colors
- **FIFA Blue:** `#0033A0` 
- **Host Nations Red:** `#E31837`
- **Trophy Gold:** `#FFD100`
- **Dark Background:** `#1A1A2E`

## 📱 Getting Your IPA (Free Method)

### Step 1: Create GitHub Repository
```bash
cd "C:\Users\RDP\Documents\IRAQ\MauiApp1"
git init
git add .
git commit -m "World Cup 2026 Live Sports App"
```

### Step 2: Push to GitHub
1. Go to https://github.com/new
2. Create a **public** repository (free)
3. Run these commands (replace YOURUSERNAME):

```bash
git remote add origin https://github.com/YOURUSERNAME/WorldCup2026.git
git branch -M main
git push -u origin main
```

### Step 3: Download Your IPA
1. Go to your repo → **Actions** tab
2. Wait for build to complete (~3-5 minutes)
3. Download the **WorldCup2026-iOS** artifact (contains the `.ipa` file)

### Step 4: Install on iPhone (Sideloadly/AltStore)
1. Open the downloaded `.ipa` in **Sideloadly**
2. Connect your iPhone via USB
3. Click **Start** to install
4. The IPA expires in **7 days** - use AltStore to refresh

## 📦 Project Structure
```
MauiApp1/
├── .github/workflows/   # GitHub Actions for free IPA builds
├── Platforms/iOS/       # iOS specific files
├── Resources/
│   ├── AppIcon/         # World Cup 2026 trophy icon
│   ├── Splash/          # Launch screen
│   └── Styles/          # Theme colors
├── MainPage.xaml        # Live games UI
└── MauiApp1.csproj      # Project configuration
```

## 🔧 To Add Real Live Scores Later
Replace the mock data in `MainPage.xaml.cs` with an API call to a sports API like:
- API-Football (rapidapi.com)
- Football-Data.org
- ESPN API

## 🚀 Next Steps
After you push to GitHub, the workflow automatically builds your `.ipa`!