# Heroes Olden Era Tool
## Description
 - Displays information from a savegame (only the most recent quicksave)
 - Limited editing capability
 - Very limited error checking (don't get crazy)

## Usage
 - Load a game in Heroes Olden Era
 - Quicksave
 - Run the tool and see what's up (this is usually when you get a bit angry when you see just what a massive advantage the AI is given).
 - Select line(s) from the ListBox(es) and tweak away. Click Write after each tweak.
   - There isn't much error-checking yet, so tweak carefully.
 - The demo is super buggy about reloads, so Exit to Main Menu, then Load the quicksave.
 - Enjoy!

## Additional usage and notes
 - If you run it in the debugger you'll see interesting lists such as all hero names and starting skills and other stuff.
 - Diff doesn't really work yet. It's intended to help you find things that changed in the json between two save files.

## Requirements
 - Visual Studio 2022 (17.14.xx) with:
  - C# w/support for .NET 9.0
  - Extensions:
     * SixLabors.ImageSharp (free version)
     * Tesseract

