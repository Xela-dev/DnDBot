# DnD Discord Bot

A Discord bot for retrieving Dungeons & Dragons (D&D) 5e information, including spells, races, classes, languages, and backgrounds, using the [DnD 5e API](https://www.dnd5eapi.co/).

## Features

- Retrieve detailed information about **backgrounds**, **races**, **classes**, **spells**, and **languages**.
- Fetch D&D resources using command-based queries.
- Uses Discord.NET for interaction and a REST API for fetching D&D 5e data.

## Installation

### Prerequisites
- [.NET 6.0+](https://dotnet.microsoft.com/)
- [Discord bot token](https://discord.com/developers/applications)
- [DnD 5e API](https://www.dnd5eapi.co/)

### Setup
1. Clone this repository:
   ```sh
   git clone https://github.com/Xela-dev/DnDBot
   cd DnDBot
   ```

2. Configure your bot token in `appsettings.json`:
   ```json
   {
     "DiscordToken": "YOUR_BOT_TOKEN"
   }
   ```

3. Restore dependencies and build:
   ```sh
   dotnet restore
   dotnet build
   ```

4. Run the bot:
   ```sh
   dotnet run
   ```

## Usage

Once the bot is running, you can use the following commands in your Discord server:

- **Retrieve a background:**
  ```
  /background [name]
  ```

- **Retrieve a race:**
  ```
  /race [name]
  ```

- **Retrieve a class:**
  ```
  /class [name]
  ```

- **Retrieve a spell:**
  ```
  /spell [name]
  ```

- **Retrieve a language:**
  ```
  /language [name]
  ```
  

## Dependencies

- [Discord.NET](https://github.com/discord-net/Discord.Net) - API wrapper for Discord
- [Newtonsoft.Json](https://www.newtonsoft.com/json) - JSON serialization
- [DnD 5e API](https://www.dnd5eapi.co/) - Public API for D&D 5e data

## License

This project is licensed under the MIT License.


