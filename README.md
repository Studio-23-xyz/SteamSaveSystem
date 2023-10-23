**Studio23.SS2.SaveSystem.Cloud** is a Unity library that enables seamless integration with Steam Cloud for saving and loading game data. This library simplifies the process of saving and retrieving game data to and from Steam Cloud for your Unity game.

## Features

- **Steam Cloud Integration**: Easily enable Steam Cloud support for your Unity game.
- **Save and Load Data**: Save and load game data to and from Steam Cloud effortlessly.

## Installation

To use this library, follow these steps:


# Installation Instructions

To install the **Studio23.SS2.SaveSystem.Steam** library via the Unity Package Manager, follow these steps:

## Step 1: Configure Scoped Registry

1. Open Unity.
2. Navigate to **Edit > Project Settings > Package Manager**.
3. In the Package Manager settings, add or edit the existing OpenUPM entry as follows:

   - **Name**: `package.openupm.com`
   - **URL**: `https://package.openupm.com`
   - **Scope(s)**: 
     - `com.cysharp.unitask`
     - `com.facepunch.steamworks`
     - `com.studio23.ss2.savesystem.steam`

4. Click **Save** or **Apply** to save your changes.

## Step 2: Access Package Manager

1. In Unity, open the Unity Package Manager window:

   - Go to **Window > Package Manager**.

2. In the Package Manager window, click the "+" button.

3. Select **Add package by name...** or **Add package from git URL...** based on your preference.

## Step 3: Install the Package

1. In the input field for adding a package by name, paste the following package name:



## Usage

1. Attach the `SaveSystemSteamCloudBehaviour` script to your game object. Or Install via Studio-23 > Save System > Install Steam Cloud

2. Configure the Steam Cloud settings using the Unity Inspector:

   - Enable or disable Steam Cloud support.
   - Set your Steam Application ID.
   - Specify the save file key.

3. The library methods will save and load game data to and from Steam Cloud automatically.

