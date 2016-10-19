# HugsLib
A lightweight shared mod library for Rimworld.
You do **not** need to install this as a separate mod- all mods that require it already include it.

Provides a foundation for mods and delivers shared functionality. Designed to be updated safely, and is able to function independently for every mod that uses it. This means that mods based on older versions of the library will still work as expected.

## Current features
- Mod foundation: Base class to build mods on. Extending classes have access to custom logging, settings, and receive the following events from the library controller: Initialize, Tick, Update, FixedUpdate, OnGUI, MapLoading, MapComponentsInitializing, MapLoaded, SettingsChanged, DefsReloaded.
- Persistent in-game settings: Implementing mods can create custom settings of various types that can be changed by the player in a custom settings menu. Settings are stored in a file in the user folder.
- Mod update news: Mods can provide a message for each version they release, highlighting new features. These message will be shown once to the player the next time he starts the game. This is a good way to ensure that non-obvious mod features do not go unnoticed by the majority of players. This is especially true on Steam, where the player may not have even read the description before subscribing. Messages include support for images and basic formatting.
- Version independence: Mods that implement the library bundle their own version of the assembly. Multiple versions of the library can run in parallel without interfering with each other. Only mods implementing the latest running version have the ability display update news and to have their settings changed in the Mod Settings menu. However, older versions will still have access to existing settings. The goal for the future is to provide full independence and allow the complete feature set to be used regardless of version.
- Custom tick scheduling: Includes tools for executing callbacks with a specified tick delay, and registering recurring ticks with non-standard intervals. Recurring ticks are distributed uniformly across the time spectrum, to minimize the performance impact of the ticking entity.
- Detouring: Forwards detouring requests to the Community Core Library when it is available, or uses own equivalent otherwise.

## Compatibility
The library does no detour any methods on its own. The only potential point of contention is Dialog_Options, which is replaced by Dialog_OptionsExtended when it appears on the WindowStack. A dynamic assembly and a type is created at runtime- something to watch out for if you iterate over all loaded types.

This library was made for use in my own mods, but I don't mind if someone else uses it. Just give me a heads-up first.
